﻿using kata_gof_chain_of_responsibility_pokerhands;
using Xunit;

namespace kata_gof_chain_of_responsibility_pokerhands_tests
{
    public class HandComparerTests
    {
        [Theory]
        [InlineData("White wins. - with high card: Ace",  "Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH")]
        [InlineData("White wins. - with high card: King", "Black: 2H 3D 5S 9C QD  White: 2C 3H 4S 8C KH")]
        [InlineData("White wins. - with high card: Seven", "Black: 2H 3D 4S 5C 6D  White: 2C 3H 4S 5C 7H")]
        [InlineData("Black wins. - with high card: Seven", "Black: 2C 3H 4S 5C 7H  White: 2H 3D 4S 5C 6D")]
        [InlineData("Black wins. - with high card: Eight", "Black: 2C 3H 4S 5C 8H  White: 2H 3D 4S 5C 6D")]
        [InlineData("Black wins. - with high card: Queen", "Black: QC 3H 4S 5C 8H  White: 2H 3D 4S 5C 6D")]
        [InlineData("Black wins. - with high card: Nine", "Black: 9C 3H 4S 5C 8H  White: 2H 3D 4S 5C 6D")]
        public void Compare_HighCard(string expected, string input)
        {
            var comparer = new HandComparer();
            var actual = comparer.Compare(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("White wins. - with pair: Ace", "Black: 2H 3D 5S 9C AD  White: 2C 3H 4S AC AH")]
        [InlineData("Black wins. - with pair: Five", "Black: 2H 3D 5S 5C AD  White: 2C 3H 4S 9C AH")]
        public void Compare_Pair(string expected, string input)
        {
            var comparer = new HandComparer();
            var actual = comparer.Compare(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Black wins. - with full house: Four over Two", "Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S")]
        [InlineData("White wins. - with full house: King over Jack", "Black: 2H 4S 4C 2D 4H  White: JS KS JS KS KS")]
        public void Compare_FullHouse(string expected, string input)
        {
            var comparer = new HandComparer();
            var actual = comparer.Compare(input);
            Assert.Equal(expected, actual);
        }
    }
}

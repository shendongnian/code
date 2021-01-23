    public class CheckDigitExtensionShould
    {
        [Fact]
        public void ComputeCheckDigits()
        {
            Assert.Equal(0, (new List<int> { 0 }).CheckDigit());
            Assert.Equal(8, (new List<int> { 1 }).CheckDigit());
            Assert.Equal(6, (new List<int> { 2 }).CheckDigit());
            Assert.Equal(0, (new List<int> { 3, 6, 1, 5, 5 }).CheckDigit());
            Assert.Equal(0, 36155.CheckDigit());
            Assert.Equal(8, (new List<int> { 3, 6, 1, 5, 6 }).CheckDigit());
            Assert.Equal(8, 36156.CheckDigit());
            Assert.Equal(6, 36157.CheckDigit());
            Assert.Equal("6", "36157".CheckDigit());
            Assert.Equal("3", "7992739871".CheckDigit());
        }
        [Fact]
        public void ValidateCheckDigits()
        {
            Assert.True((new List<int> { 3, 6, 1, 5, 6, 8 }).HasValidCheckDigit());
            Assert.True(361568.HasValidCheckDigit());
            Assert.True("361568".HasValidCheckDigit());
            Assert.True("79927398713".HasValidCheckDigit());
        }
        [Fact]
        public void AppendCheckDigits()
        {
            Console.WriteLine("36156".CheckDigit());
            Console.WriteLine("36156".AppendCheckDigit());
            Assert.Equal("361568", "36156".AppendCheckDigit());
            Assert.Equal("79927398713", "7992739871".AppendCheckDigit());
        }
    }

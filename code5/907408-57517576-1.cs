        [Theory]
        [InlineData("same", "same")]
        [InlineData("Simple", "simple")]
        [InlineData("MultiWord", "multi-word")]
        [InlineData("UsingAnAWord", "using-an-a-word")]
        [InlineData("SomeDigit4Used2", "some-digit4-used2")]
        public void UrlConvertWorks(string input, string expected)
        {
            Assert.Equal(expected, Meta.UrlConvert(input));
        }

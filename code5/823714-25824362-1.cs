    public class HttpParseQueryValuesTests
    {
        [TestCase("http://www.example.com", 0, "", "")]
        [TestCase("http://www.example.com?query=value", 1, "query", "value")]
        public void When_parsing_http_query_then_should_have_these_values(string uri, int expectedParamCount,
            string expectedKey, string expectedValue)
        {
            var queryParams = HttpUtility.ParseQueryString(new Uri(uri));
            queryParams.Count.Should().Be(expectedParamCount);
            if (queryParams.Count > 0)
                queryParams[expectedKey].Should().Be(expectedValue);
        }
    }

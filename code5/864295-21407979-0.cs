    public static class ShouldBeHelper
    {
        public static void ShouldBeSameContent(this HttpRequestMessage result, object expected)
        {
            result.Should().BeOfType<ObjectContent>();
            ((ObjectContent)result.Content).ShouldBeEquivalentTo(new ObjectContent(expected.GetType(), expected, new JsonMediaTypeFormatter(),
                options => options.Including(x => x.Value));
        }
    }

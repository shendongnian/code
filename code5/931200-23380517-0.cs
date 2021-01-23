    public static void MockQueryString(IEnumerable<Tuple<string, string>> qstringTuples, 
                                       Controller controller)
    {
        // Convert collection to IEnum<NameValueCollection>
        var queryStrings = qstringTuples
            .Select(_ => new NameValueCollection {{_.Item1, _.Item2}})
            .ToList();
        // Set up a request
        var request = new Mock<System.Web.HttpRequestBase>();
        var queryStringIterator = queryStrings.GetEnumerator();
        request.Setup(r => r.QueryString)
               .Returns(() =>
                            {
                                queryStringIterator.MoveNext();
                                return queryStringIterator.Current;
                            });

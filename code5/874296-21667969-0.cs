    static void Process()
    {
        var searchReader =
            new TransformManyBlock<SearchResult, SearchResult>(async uri =>
        {
            // return a list of search results at uri.
            return new[]
            {
                new SearchResult
                {
                    IsResult = true,
                    Uri = "http://foo.com"
                },
                new SearchResult
                {
                    // return the next search result page here.
                    IsResult = false,
                    Uri = "http://google.com/next"
                }
            };
        }, new ExecutionDataflowBlockOptions
        {
            BoundedCapacity = 8, // restrict buffer size.
            MaxDegreeOfParallelism = 4 // control parallelism.
        });
        // link "next" pages back to the searchReader.
        searchReader.LinkTo(searchReader, x => !x.IsResult);
        var resultActor = new ActionBlock<SearchResult>(async uri =>
        {
            // do something with the search result.
        }, new ExecutionDataflowBlockOptions
        {
            BoundedCapacity = 64,
            MaxDegreeOfParallelism = 16
        });
        // link search results into resultActor.
        searchReader.LinkTo(resultActor, x => x.IsResult);
        // put in the first piece of input.
        searchReader.Post(new SearchResult { Uri = "http://google/first" });
    }
    struct SearchResult
    {
        public bool IsResult { get; set; }
        public string Uri { get; set; }
    }

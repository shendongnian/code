    var searchRequest = new SearchRequest
    {
        Query = ..
        Highlight = new Highlight
        {
            PostTags = new[] {"<a>"},
            PreTags = new[] {"</a>"},
            Fields = new FluentDictionary<Field, IHighlightField>().Add("*", new HighlightField())
        }
    };

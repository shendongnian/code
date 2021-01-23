    private void fetchFeaturedArticles()
    {
        var client = new RestClient (_featuredArticlesJsonUrl);
        var request = new RestRequest (Method.GET);
        var response = client.Execute (request);
        Dictionary<string, Articles> _featuredArticles = JsonConvert.DeserializeObject<Dictionary<string, Articles>>(response.Content);
        foreach (string key in _featuredArticles.Keys)
        {
            Console.WriteLine(_featuredArticles[key].Title);
        }
    }

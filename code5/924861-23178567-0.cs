    private IEnumerable<Task<Scraper>> ScrappedUrls()
    {
        // Return the 50 to 60 task for each website here. 
        // I assume they all return the same type.
        // return .ScrapeUrlAsync().ConfigureAwait(false);
        throw new NotImplementedException();
    }
    public  async Task<IEnumerable<ScrapeOdds>> GetOdds()
    {
        var results = new Collection<ScrapeOdds>();
        var urlRequest = ScrappedUrls();
        var observerableUrls = urlRequest.Select(u => u.ToObservable()).Merge();
        var publisher = observerableUrls.Publish();
        var hubContext = GlobalHost.ConnectionManager.GetHubContext<OddsHub>();
        publisher.Subscribe(scraper =>
            {
                // Whatever you do do convert to the result set
                var scrapedOdds = scraper.GetOdds();
                results.Add(scrapedOdds);
                // update anything else you want when it arrives.
                // Update SingalR here 
                hubContext.Clients.All.UpdatedOdds(scrapedOdds);
            });
        // Will fire off subscriptions and not continue until they are done.
        await publisher;
        return results;
    }

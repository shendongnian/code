    //Create an instance of the crawler and subscribe to the PageCrawlCompleted event
    PoliteWebCrawler crawler = new PoliteWebCrawler();
    crawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompleted;
    //The event handler method
    void crawler_ProcessPageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
    {
        CrawledPage crawledPage = e.CrawledPage;
        if (crawledPage.WebException != null || crawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
            Console.WriteLine("Crawl of page failed {0}", crawledPage.Uri.AbsoluteUri);
        else
            Console.WriteLine("Crawl of page succeeded {0}", crawledPage.Uri.AbsoluteUri);
        //crawledPage.RawContent   //raw html
        //crawledPage.HtmlDocument //lazy loaded html agility pack object (HtmlAgilityPack.HtmlDocument)
        //crawledPage.CSDocument   //lazy loaded cs query object (CsQuery.Cq)
    }

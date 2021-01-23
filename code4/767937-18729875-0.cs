    for (int i = 0; i < WebSitesToCrawl.Count; i++)
    {
        _busy.WaitOne();
        //...
    }

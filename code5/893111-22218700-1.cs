    Task.Factory.StartNew(
            () => Db.Search(ResourceOrAutor, TxSearch.Text.Trim()) )
    .ContinueWith(t =>
    {
        //Move the rest of your code here....
        List<BookAuthorsFieldSet> Resources = t.Result;
        //......
    },TaskScheduler.FromCurrentSynchronizationContext());

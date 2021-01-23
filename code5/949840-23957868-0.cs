    public void AddToCollection_Short<T>(IEnumerable<T> query) where T : IAmCommonInterface
    {
        List<object> list = new List<object>();
        foreach (T item in query)
        {
            var obj = new object();
            var date = item.Date.ToShortDateString();
            obj = new { date, item.Id, item.Subject };
            list.Add(obj);
        }
        AllQueries = list;
        OnPropertyChanged("AllQueries");
    }

    public void AddToCollection_Short(IEnumerable query)
    {
        List<object> list = new List<object>();
        foreach (dynamic item in query)
        {
            var obj = new object();
            var date = item.Date.ToShortDateString();
            obj = new { date, item.Id, item.Subject };
            list.Add(obj);
        }
        AllQueries = list;
        OnPropertyChanged("AllQueries");
    }

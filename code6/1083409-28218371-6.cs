    public TopGridItem()
    {
        _collection = new ObservableCollection<BottomGridItem>();
        _collection.Add(new BottomGridItem { Name = "bbbbbb" });
        _collection.Add(new BottomGridItem { Name = "aaaaa" });
        _collection.Add(new BottomGridItem { Name = "aaaaa" });
        _collection.Add(new BottomGridItem { Name = "ccccc" });
        _collection.Add(new BottomGridItem { Name = "dddddd" });
        ResetView();
    }

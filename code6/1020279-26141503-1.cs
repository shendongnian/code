    public ObservableCollection<Fields> Items
    {
        get
        {
            return items ?? (items = new ObservableCollection<Fields>());
        }
    }
    private ObservableCollection<Fields> items;
    var newItems = jObj.Children().Select(jo => jo["result"]["fields"].ToObject<Fields>());
    Items.Clear();
    foreach (var item in newItems)
    {
        Items.Add(item);
    }

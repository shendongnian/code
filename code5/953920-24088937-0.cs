    private static readonly BlockingCollection<int> Items = new BlockingCollection<int>();
    //ThreadA
    public void LoadStuff()
    {
        Items.Add(1);
        Items.Add(2);
        Items.Add(3);
    }
    //ThreadB
    public void DoStuff()
    {
        foreach (var item in Items.GetConsumingEnumerable())
        {
            //Do stuff here
        }
    }

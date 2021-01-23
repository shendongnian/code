    public Boolean _Sold
    {
        get { return Sold; }
        set
        {
            Sold = value;
            if (Sold)
            {
                OnSell("your string here");
            }
        }
    }
    public void OnSell(string str)
    {
        SellEventHandler handler = _OnSell;
        if (handler != null)
        {
            handler(str);
        }
        Console.WriteLine("library stuff");
    }

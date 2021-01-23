    public static Task<ObservableCollection<MyResult>> GetMyData(Params p)
    {
        DoStuffClass stuff = new DoStuffClass();
    
        return Task.Factory.StartNew(() => stuff.LongDrawnOutProcess(p));
    }

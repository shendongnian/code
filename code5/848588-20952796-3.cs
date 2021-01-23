    public static async Task<ObservableCollection<MyResult>> GetMyData(Params p)
    {
        DoStuffClass stuff = new DoStuffClass();
    
        return await Task.Factory.StartNew(() => stuff.LongDrawnOutProcess(p));
    }

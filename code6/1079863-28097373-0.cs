    private void PrepareData(object o, MyFunc func)
    {
        DoJob(() => func(o));
    }
    
    private void DoJob(Action wParam)
    {
        if (wParam != null)
        {
            wParam();
        }
    }

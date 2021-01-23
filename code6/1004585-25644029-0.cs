    public string PropertyA
    {
        get;
        set
        {
            DoSomething(MethodBase.GetCurrentMethod().Name.Substring(4));
        }
    }

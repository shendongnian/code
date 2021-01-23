    private BindType bindProp = TempData;
    public BindType BindProp 
    {
        get
        {
             return bindProp;
        }
    }
   
    private void LoadDone(BindType realData)
    {
        bindProp= realData;
        // Notify BindProp property changed
    }

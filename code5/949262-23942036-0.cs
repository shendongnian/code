    private string symbol;
    public string Symbol
    {
        get { return symbol; }
        set
        {
             if(symbol == value) return; //this is optional
             symbol = value;
             lastUpdate = DateTime.Now;
        }
    }

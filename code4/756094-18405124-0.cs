    public FontWeight Bmw
    {
        /// here shouldn't be any code, just getters and setters
        get { return bmw; }
        set { bmw = value; }
    
        /// you forgot to close the property here
    } /// now it's closed
    public void Dispose()
    {
        bmw.Dispose(); /// now it will work
    }

    public string GetVersion() 
    {
        string version ;
        version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        return version;
    }
    

    public string Version
    {
        get
        {
            return System.Reflection.Assembly
                .GetExecutingAssembly().GetName().Version.ToString();
        }
    }

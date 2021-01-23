    public static List<string> Symbols
    {
        get
        {
            var sym = ConfigurationManager.AppSettings["Symbols"];
            return sym.Split(',').Select(x=>x.Trim()).ToList();
        }
    }

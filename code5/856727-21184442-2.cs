    public static List<string> Symbols
    {
        get
        {
            Sys = ConfigurationManager.AppSettings["Symbols"];
            string[] sys1 = Sys.Split(',');
            Symbols = new List<string>();
            foreach (string item in sys1)
            {
                Symbols.Add(item.Trim());
            }
            return Symbols;
        }
    }

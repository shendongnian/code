    private static readonly List<string> _censoredWords  = System.Configuration.ConfigurationManager.AppSettings["keywords"].Split(',').ToList();
    public static IList<string> CensoredWords
    {
        get
        {
             return _keywords;
        }
    }

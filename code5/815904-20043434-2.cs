    public static Dictionary<string, int> MenuContent = new Dictionary<string, int>();
    // This was changed
    public static List<string> namelist { get; set; }
    // **ctor with FillM() inside**
    private void FillM()
    {
            MenuContent.Add("לחם", 5);
            MenuContent.Add("חלב", 5);
            MenuContent.Add("ביצה", 10);
            MenuContent.Add("סלט", 15);
            MenuContent.Add("טוסט", 10);
            MenuContent.Add("בשר", 20);
            MenuContent.Add("קינוח", 100);
        // this is to avoid a null reference when filling
        namelist =  new List<string>();
        foreach (KeyValuePair<string, int> item in MenuContent)
        {
            namelist.Add(item.Key);
        }
    }

    static void Main(string[] args)
    {
        var text = System.Web.HttpUtility.HtmlDecode("assd&#xF;abv");
        Console.WriteLine(_invalidXMLChars.IsMatch(text));
    }

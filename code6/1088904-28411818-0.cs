    public string FormatHTML(object myStringObject)
    {
        string myString = Convert.ToString(myStringObject);
        return Server.HtmlDecode(myString);
    }

    public string GetConvertedVdiXML(string myText, int newValue)
    {
        string text = myText;
        Regex r = new Regex(@"Secured=""[^""]*"" ");
        text = r.Replace(text, "EditableBy=\"" + newValue.ToString() + "\" ");
        return text;
    }
           

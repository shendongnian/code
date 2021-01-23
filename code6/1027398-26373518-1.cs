    public string HTMLDecode(value)
    {
        System.IO.StringWriter writer = new System.IO.StringWriter();
        HttpUtility.HtmlDecode(value, writer);
        return writer.ToString();
    }

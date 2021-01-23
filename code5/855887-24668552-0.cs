    int pageCount;
    MemoryStream stream = new MemoryStream(pdfContent);
    using (var r = new StreamReader(stream))
    {
        string pdfText = r.ReadToEnd();
        System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");
        System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);
        pageCount = matches.Count;
    }

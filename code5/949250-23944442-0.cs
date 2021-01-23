    using HtmlAgilityPack;
    ...
    private string AppendCdnToImgSrc(string htmlString)
    {
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(htmlString); // or htmlDoc.Load(htmlFileName) if a file
        foreach(HtmlNode img in doc.DocumentElement.SelectNodes("//img[@src]")
        {
            HtmlAttribute attribute = img["src"];
            attribute.Value = attribute.Value + ".cdn";
        }
        
        // return string output...
        MemoryStream memStream = new MemoryStream();
        htmlDoc.Save(memStream)
        memStream.Seek(0, System.IO.SeekOrigin.Begin);
        StreamReader reader = new StreamReader(memStream);
        return reader.ReadToEnd();
    }

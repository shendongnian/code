    HtmlDocument document = WebBrowser.Document;
    if (document != null) {                    
        HtmlElementCollection tableCollection = document.GetElementsByTagName("tbody");
        foreach (HtmlElement table in tableCollection) {
            HtmlElementCollection trColl = table.GetElementsByTagName("tc");
            foreach (HtmlElement row in trColl) {
                tds = row.GetElementsByTagName("td");
                if (tds != null && tds.Count > 1) {
                    string neededText = tds[0].InnerText;
                    // 1.iteration: neededText == abcdefg
                    // 2.iteration: neededText == 123456
                    // 3.iteration: neededText == qwertyo
										
                }
            }
        }
    }

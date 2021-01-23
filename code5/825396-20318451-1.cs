    byte[] data;
    using (WebClient webClient = new WebClient())
        data = webClient.DownloadData(urlToDocument);
    
    string str = Encoding.Default.GetString(data);
    var doc = XDocument.Load(str);
    var node = doc.Descendants("period")
                    .Where(elem => elem.Value == "0")
                    .First().NextNode;
    var fcText = ((XElement)node).Value;

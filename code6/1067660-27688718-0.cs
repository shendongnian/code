    string urls = "your web page";
            string result = string.Empty;
    
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urls);
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
    
            using (var stream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
    
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(new StringReader(result));
    
            var elements = doc.DocumentNode.SelectNodes("//div[@class='one-third column']");
            foreach (HtmlNode item in elements)
            {
                var node1 = item.SelectNodes(".//li");
                foreach (HtmlNode li in node1)
                {
                    var a = li.SelectSingleNode("//a").Attributes["href"].Value;//your link
                }
    
            }

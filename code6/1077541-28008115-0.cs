            string data  = "";
            using (WebClient client = new WebClient())
            {
                data = client.DownloadString(url);
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            doc.Load(stream);

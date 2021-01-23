            string cookie = string.Empty;
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create("http://webtruyen.com");
            try
            {
                using (Stream s = hwr.GetResponse().GetResponseStream())
                { }
            }
            catch (WebException wx)
            {
                cookie = Regex.Match(new StreamReader(wx.Response.GetResponseStream()).ReadToEnd(), "document.cookie = '(.*?)';").Groups[1].Value;
            }
            hwr = (HttpWebRequest)WebRequest.Create("http://webtruyen.com");
            hwr.Headers.Add("Cookie", cookie);
            HtmlDocument doc = new HtmlDocument();
            using (Stream s = hwr.GetResponse().GetResponseStream())
            using (StreamReader sr = new StreamReader(s))
            {
                doc.LoadHtml(sr.ReadToEnd());
            }

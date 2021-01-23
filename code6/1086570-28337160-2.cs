            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create("http://webtruyen.com");
            HtmlDocument doc = new HtmlDocument();
            try
            {
                using (Stream s = hwr.GetResponse().GetResponseStream())
                { }
            }
            catch (WebException wx)
            {
                doc.LoadHtml(new StreamReader(wx.Response.GetResponseStream()).ReadToEnd());
            }

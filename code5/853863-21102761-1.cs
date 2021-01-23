    private string getTextfrom()
    {
        HtmlDocument doc = new HtmlDocument();
        //doc.LoadHtml("<span itemprop=\"price\" content=\"164,06\"></span>");
        string htmlContent = GetPageContent("http://pastebin.com/raw.php?i=zE31NWtU");
        doc.LoadHtml(htmlContent);
        
        HtmlNode priceNode = doc.DocumentNode.SelectNodes("//span")[0];
        HtmlAttribute valueAttribute = priceNode.Attributes["content"];
        return valueAttribute.Value;
    }
    public static String GetPageContent(string Url)
    {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
        myRequest.Method = "GET";
        WebResponse myResponse = myRequest.GetResponse();
        StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        string result = sr.ReadToEnd();
        sr.Close();
        myResponse.Close();
        return result;
    }

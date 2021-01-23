    protected void BtnIndex_Click(object sender, EventArgs e)
    {
	string source = getHtml("http://stackoverflow.com");
	HtmlDocument doc = new HtmlDocument();
	doc.LoadHtml(source);
	HtmlNodeCollection cont;
	cont = doc.DocumentNode.SelectNodes("//div[@id='wrapper']");
}
    string getHtml(string url)
    {
        string Shtml = string.Empty; ;
        try
        {
            //WebClient client = new WebClient();
            //client.Encoding = Encoding.UTF8;
            //Shtml = client.DownloadString(url);
            //Shtml = new WebClient().DownloadString(url); bejoz utf-8
            HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myWebRequest.Method = "GET";
            // make request for web page
            HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            StreamReader myWebSource = new StreamReader(myWebResponse.GetResponseStream());
            Shtml = myWebSource.ReadToEnd();
            myWebResponse.Close();
        }
        catch
        {
            Response.Write(" error:  " + url + Environment.NewLine);
        }
        return Shtml;
    }

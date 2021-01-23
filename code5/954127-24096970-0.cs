    private void button1_Click(object sender, EventArgs e)
    {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://api.eve-central.com/api/quicklook?typeid=34&usesystem=30002053");
        myRequest.Method = "GET";
        XDocument doc;
        using (WebResponse myResponse = myRequest.GetResponse())
        using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
        {
            string result = sr.ReadToEnd();
            MessageBox.Show(result);
            doc = XDocument.Parse(result);
        }
        IEnumerable<string> prices = from price in doc.Descendants("order") select (string)price.Attribute("price");
    }

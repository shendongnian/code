    string uri = "http://localhost:28642/api/InventoryItems";
    var webRequest = (HttpWebRequest)WebRequest.Create(uri);
    webRequest.Method = "GET";
    using (var webResponse = (HttpWebResponse) webRequest.GetResponse())
    {
        if (webResponse.StatusCode == HttpStatusCode.OK)
        {
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            int recCount;
            Int32.TryParse(s, out recCount);
            labelInvItemsCount.Text = string.Format("== {0}", recCount);
        }
    }

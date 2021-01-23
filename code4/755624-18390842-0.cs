        private void button1_Click(object sender, EventArgs e)
        {
            string uriString = "http://www.google.com/search";
            string keywordString = "Test Keyword";
            WebClient webClient = new WebClient();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("q", keywordString);
            webClient.QueryString.Add(nameValueCollection);
            textBox1.Text = webClient.DownloadString(uriString);
        }

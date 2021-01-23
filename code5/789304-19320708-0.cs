            url = "http://" + toolStripTextBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream pageStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(pageStream,Encoding.Default);
            string s = reader.ReadToEnd();
            webBrowser1.DocumentText = s;
        }`

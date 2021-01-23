        WebRequest wr = WebRequest.Create("https://api.newrelic.com/v2/applications.json");
        wr.ContentType = "application/json";
        wr.Method = "GET";
        wr.Headers.Add("X-Api-Key:xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        using (WebResponse response = wr.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                byte[] bytes = new Byte[10000];
                int n = stream.Read(bytes, 0, 9999);
                string s = System.Text.Encoding.ASCII.GetString(bytes);
            }
        }

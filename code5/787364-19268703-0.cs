        var request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "GET";
        request.ContentType = "application/xml";
        request.Accept = "application/xml";
        using (var response = request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                var reader = new XmlTextReader(stream);
                while (reader.Read())
                {
                    Console.WriteLine(reader.Value);
                }
            }
        }

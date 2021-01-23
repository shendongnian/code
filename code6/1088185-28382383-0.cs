        WebClient client = new WebClient();
        String CreatePublicUrl = String.Format("{0}/DataObjectServer/data/do/getproperties?cat=do&key=baseXmlPath&t={1}", base_url.Value, token);
        using (Stream data = client.OpenRead(CreatePublicUrl))
        {
            using (StreamReader reader = new StreamReader(data))
            {
                string content = reader.ReadToEnd();
            }
        }

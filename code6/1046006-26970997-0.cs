        string url = "Your url";
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentType = "application/json";
        List<string> values = new List<string>();
        values.Add(groupValue);
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                apikey = apiKey,
                id = listId,
                name = groupName,
                type = "radio",
                groups = values
            });
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var grouping = new JavaScriptSerializer().Deserialize(result, typeof(MailchimpGrouping));
                if (grouping != null)
                {
                    return (grouping as MailchimpGrouping).Id;
                }
            }
        }
        return 0;
        
    }

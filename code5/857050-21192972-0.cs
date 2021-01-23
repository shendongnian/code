    try
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        var webResponse = (HttpWebResponse)webRequest.GetResponse();
        if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
        {
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<JArray>(s);
        }
        MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));    
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    return null;

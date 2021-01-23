    private JArray GetRESTData(string uri)
    {
        JArray ret = null; // single return value, declared outside of try/catch
        try
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
            {
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                ret = JsonConvert.DeserializeObject<JArray>(s);
            }
            MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return ret;
    }

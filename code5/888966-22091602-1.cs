    public static object ReadJsonResponseAs(this HttpWebRequest webRequest, Type type)
    {
        using (System.IO.Stream responseStream = webRequest.GetResponse().GetResponseStream())
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(responseStream))
            {
                object result = JsonConvert.DeserializeObject(sr.ReadToEnd(), type);
    
                responseStream.Close();
                return result;
            }                    
        }
    }

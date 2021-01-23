    // get soap result
    using (WebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncReslt))
    {
        using (Stream dataStream = webResponse.GetResponseStream())
        {
            StreamReader sReader = new StreamReader(webResponse.GetResponseStream())
            soapResult = sReader.ReadToEnd();
        }
    }

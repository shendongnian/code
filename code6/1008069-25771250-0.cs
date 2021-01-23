    // get soap result
    using (WebResponse webResponse = webRequest.EndGetResponse(asyncReslt))
    {
        using (StreamReader sReader = new StreamReader(webResponse.GetResponseStream()))
        {
            soapResult = sReader.ReadToEnd();
        }
    }

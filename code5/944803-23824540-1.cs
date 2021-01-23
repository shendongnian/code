    Windows.Web.Http.HttpClient oHttpClient = new Windows.Web.Http.HttpClient();
    Uri uri= ... // some Url
    string stringXml= "...";  // some xml string
    HttpRequestMessage mSent = new HttpRequestMessage(HttpMethod.Post, uri);
    mSent.Content = 
      new HttpStringContent(String.Format("xml={0}", stringXml), 
                            Windows.Storage.Streams.UnicodeEncoding.Utf8);
    
    HttpResponseMessage mReceived = await oHttpClient.SendRequestAsync(mSent,
                                       HttpCompletionOption.ResponseContentRead);
    
    // to get the xml response:
    if (mReceived.IsSuccessStatusCode)
    {
      string strXmlReturned await mReceived.Content.ReadAsStringAsync();
    }

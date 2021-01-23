    private void YourCurrentMethod()
    {
        string URI = "http://localhost/1/index.php?dsa=232323";
        string myParameters = "";
        URI = URI + "&" + myParameters; 
    
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URI);
    
        request.ContentType="application/x-www-form-urlencoded";
    
        request.BeginGetResponse(GetResponseCallback, request);
    }
    
    void GetResponseCallback(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;
        if (request != null)
        {
            try
            {
                WebResponse response = request.EndGetResponse(result);
                //Do what you want with this response
            }
            catch (WebException e)
            {
                return;
            }
        }
    }

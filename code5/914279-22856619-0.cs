    void myCallback(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;
        if (request != null)
        {
            try
            {
                WebResponse response = request.EndGetResponse(result);
                //Do stuff with your response
            }
            catch (WebException e)
            {
                //Handle exception
            }
        }
    }

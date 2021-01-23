    void myCallback(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;
        if (request != null)
        {
            try
            {
                HttpWebResponse response = request.EndGetResponse(result);
                //You can check the response code this way
                if (reponse.StatusCode == HttpStatusCode.OK) {
                    //Do stuff with your response
                }
            }
            catch (WebException e)
            {
                //Handle exception
            }
        }
    }

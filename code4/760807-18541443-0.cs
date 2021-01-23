    try
    {
        HttpWebRequest request = HttpWebRequest.Create("yoururl") as HttpWebRequest;
        request.Method = "HEAD"; //Get only the header information -- no need to download any content
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            int statusCode = (int)response.StatusCode;
            if (statusCode >= 100 && statusCode < 400) //Good requests
            {
            }
            else //if (statusCode >= 500 && statusCode <= 510) //Server Errors
            {
                //Hard to reach here since an exception would be thrown 
            }
        }
    }
    catch (WebException ex)
    {
        //handle exception
        //something wrong with the url
    }

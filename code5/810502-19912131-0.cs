    private void request_3()
    {
        bool sendData = true;
        int numberOfTimeOuts = 0;
    
        byte[] dataToSend = Encoding.ASCII.GetBytes(post_data_final);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site_URI);
        using (Stream outputStream = request.GetRequestStream())
            outputStream.Write(dataToSend, 0, dataToSend.Length);
	
        // request.TimeOut = 1000 * 15; would mean 15 Seconds.
        while(sendData && numberOfTimeOuts < MAX_NUMBER_OF_TIMEOUTS)
        {
             try
             {
                 HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                 if(response != null)
                     processResponse(response);
                 else
                 {
                     //You should handle this case aswell.
                 }
			 
                 sendData = false;
             }
             catch(WebException wex)
             {
                 if (wex.Status == WebExceptionStatus.Timeout)
                     numberOfTimeOuts++;
                 else
                     throw;
             }
        }
    }

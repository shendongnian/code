    private byte[] DownloadFile( string uri, int requestTimeout, int downloadTimeout, out bool isTimeout, out int bytesDownloaded )
    {
        HttpWebRequest request = WebRequest.Create( uri ) as HttpWebRequest;
        request.Timeout = requestTimeout;
        HttpWebResponse response = null;
        Stream responseStream = null;
        MemoryStream downloadedData = null;
        byte[] result = null;
        bytesDownloaded = 0;
        isTimeout = false;
        try
        {
            // Get response
            response = request.GetResponse() as HttpWebResponse;
            byte[] buffer = new byte[ 16384 ];
            // Create buffer for downloaded data
            downloadedData = new MemoryStream();
            // Set the timeout
            DateTime timeout = DateTime.Now.Add( new TimeSpan( 0, 0, 0, 0, downloadTimeout ) );
            // Read parts of the stream
            responseStream = response.GetResponseStream();
            int bytesRead = 0;
            DateTime now = DateTime.Now;
            while ( (bytesRead = responseStream.Read( buffer, 0, buffer.Length )) > 0 && DateTime.Now < timeout )
            {
                downloadedData.Write( buffer, 0, bytesRead );
                now = DateTime.Now;
                bytesDownloaded += bytesRead;
            }
            // Notify if timeout occured (could've been written better)
            if ( DateTime.Now >= timeout )
            {
                isTimeout = true;
            }
        }
        catch ( WebException ex )
        {
            // Grab timeout exception
            if ( ex.Status == WebExceptionStatus.Timeout )
            {
                isTimeout = true;
            }
        }
        finally
        {
            // Close the stream
            if ( responseStream != null )
            {
                responseStream.Close();
            }
        }
        if ( downloadedData != null )
        {
            result = downloadedData.GetBuffer();
            downloadedData.Close();
        }
        return result;
    }

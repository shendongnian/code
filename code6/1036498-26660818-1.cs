    foreach (var ip in ipAddressList)
    {
        HttpWebResponse myHttpWebResponse = null;
        try
        {
            var myUri = new Uri(ip.Url);
            // Create a 'HttpWebRequest' object for the specified url. 
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
            // Set the user agent as if we were a web browser
            myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";
            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            // Release resources of response object.
            myHttpWebResponse.Close();
        }
        catch (WebException ex)
        {
            // If we get here, port is not open, or host is not reachable
            UpdateDowntime(ip, ex.Message);
        }
        finally
        {
            if (myHttpWebResponse != null)
            {
                myHttpWebResponse.Close();
            }
        }
    }

    public void ProcessAsyncResult(IAsyncResult result)
        {
            ServiceSoapClient srv = result.AsyncState as ServiceSoapClient;
            if (srv == null) return;
            try
            {
                srv.EndAddDocument(result);
            }
            catch (WebException ex)
            {
                //your code to handle exception here
            }
        }

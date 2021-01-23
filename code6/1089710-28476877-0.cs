    stream = BTClient.GetStream();
    public void Disconnect()
        {
                if (BTClient == null )
                    return;
       
                try
                {
                    if (BTClient != null)
                    {
                        if (stream != null)
                        {
                            stream.ReadTimeout = 500;
                            stream.WriteTimeout = 500;
                            stream.Close();
                        }
                        if(BTClient.Connected)
                            BTClient.Close();
                        BTClient.Dispose();                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            
        }

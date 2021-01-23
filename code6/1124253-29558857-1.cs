      HttpWebResponse response=null;
                Stream dataStream;
                try
                {
                    response = (HttpWebResponse) req.GetResponse();
                    dataStream = response.GetResponseStream();
    
                    StreamReader reader = null;
                    try
                    {
                        //DataStream is accessed while response object is alive, and connected (not disposed)
                        reader = new StreamReader(dataStream);
                        data = reader.ReadToEnd();
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Dispose();
                    }
                }
                finally
                {
                    if(response!=null)
                        ((IDisposable)response).Dispose();
                }

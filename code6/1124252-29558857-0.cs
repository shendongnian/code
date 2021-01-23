                HttpWebResponse response=null;
                Stream dataStream;
                try
                {
                    response = (HttpWebResponse) req.GetResponse();
                    dataStream = response.GetResponseStream();
                }
                finally
                {
                    if(response!=null)
                        ((IDisposable)response).Dispose();
                }
    
                StreamReader reader = null;
                try
                {
                    //DataStream is accessed AFTER response object is disposed 
                    reader = new StreamReader(dataStream);
                    data = reader.ReadToEnd();
                }
                finally
                {
                    if(reader!=null)
                        reader.Dispose();
                }

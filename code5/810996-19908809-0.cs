    public T Deserialise<T>(string fileName)
            {
                try
                {           
                    XmlSerializer sx = new XmlSerializer(typeof(T)); //or T.GetType?
                    StreamReader sr = new StreamReader(fileName);
                    var data = sx.Deserialize(sr);
                    sr.Close();
                  
                    return (T)data;
                }
                catch (Exception ex)
                {
    
                    throw;
                }
            }

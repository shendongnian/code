    public static T FromJSON<T>(string jsonValue, IEnumerable<Type> knownTypes)
    			{
    				//validate input parameters here
    
    				T result = default(T);
    
    				try
    				{
    					using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(jsonValue)))
    					{					
    						DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), knownTypes);
    						result = (T)serializer.ReadObject(stream);
    					}
    				}
    				catch (Exception exception)
    				{
    					throw new Exception("An error occurred while deserializing", exception);
    				}
    
    				return result;
    			}

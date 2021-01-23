    [Serializable]
    public class SerializableDictionary<T1,T2>
    {
    	public List<KeyValuePair<T1,T2>> SerializedDictionary { get; set; }
    
    	public SerializableDictionary( Dictionary<T1,T2> dictionary )
    	{
    		if( dictionary != null && dictionary.Count > 0 )
    		{
    			SerializedDictionary = dictionary.Select( item => item ).ToList();
    		}
    		else 
    		{
    			throw new ArgumentNullException( "Cannot serialize a null or empty dictionary" );
    		}
    	}
    	
    	public static explicit operator SerializableDictionary<T1,T2>(Dictionary<T1,T2> dictionary) 
    	{
    		return new SerializableDictionary<T1,T2>(dictionary);
    	}
    	
    	public static explicit operator Dictionary<T1,T2>(SerializableDictionary<T1,T2> dictionary) 
    	{
    		if ( dictionary.SerializedDictionary == null ) return null;
    		return dictionary.SerializedDictionary.ToDictionary( item => item.Key, item => item.Value );
    	}
    }

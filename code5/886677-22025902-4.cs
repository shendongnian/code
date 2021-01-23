    public class myDynamicClassDataLine : System.Dynamic.DynamicObject
    { 
       string[] _lineContent; // Actual line data
       List<string> _headers; // Associated headers (properties)
       
       public string this[string indexer]
       {
          get 
    	  {
    	     string result = string.Empty;
    	     int index = _headers.IndexOf(indexer);
    			
    	     if (index >= 0 && index < _lineContent.Length)
    	        result = _lineContent[index];
    			   
    	     return result;
    	  }
    
      }
    }

    public class myDynamicClass  : System.Dynamic.DynamicObject
    { 
       
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

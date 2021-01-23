    public String ConvertImageURLToBase64(String url) 
            {  
               StringBuilder _sb = new StringBuilder(); 
    
               Byte[] _byte = this.GetImage(url); 
    
               _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));  
               return _sb.ToString();  
            }
  
 

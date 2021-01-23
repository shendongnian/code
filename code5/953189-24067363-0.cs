    public static class ObjectExtensions
    {
        public String ToStringOrEmpty(this object obj)
        {
            if(obj == null)
               return String.Empty;
    
            return obj.ToString();
        } 
    }

     public static class SessionHelper
     {
      public static int PropertyCustCode
      {
        get
        {
            int result = 0;
            if (int.TryParse(HttpContext.Current.Session[propertyCode], out result){
                return result;
            }
            else
            {
                throw new Exception("HttpContext.Current.Session[propertyCode] is not a integer");
            } 
        }
        set
        {
              HttpContext.Current.Session[propertyCode] = value.ToString();
        }
    }

    public static class MySessions
    {
        public static List<Information> MyData
        {
         get{
            //EDIT in the GET
            if(HttpContext.Current.Session["MyInformation"] != null)
              return (List<information>)HttpContext.Current.Session["MyInformation"];
            else
              {
              HttpContext.Current.Session["MyInformation"] = new List<Information>();
              return new List<Information>();
              } 
             }
         set{HttpContext.Current.Session["MyInformation"] = value;}
        }
    }

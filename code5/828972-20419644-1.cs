    public static class MySessions
    {
        public static List<Information> MyData
        {
         get{
            //EDIT in the GET
            if(Session["MyInformation"] != null)
              return (List<information>)Session["MyInformation"];
            else
              {
              Session["MyInformation"] = new List<Information>();
              return new List<Information>();
              } 
             }
         set{Session["MyInformation"] = value;}
        }
    }

    public static class MySessions
    {
        public static List<Information> MyData
        {
         get{return (List<information>)Session["MyInformation"];}
         set{Session["MyInformation"] = value;}
        }
    }

      private List<string> list;
      public List<string> List
      {
         get
         {
             if(list == null)
             {
                list = new List<string>();
             }
             return list;  
         }
      }

    public List<searchProducts_Result> GetProducts()
    {
       var nameParam = new ObjectParameter("numbers", typeof(int));
       List<searchProducts_Result> listobjs = new List<searchProducts_Result>();
    
       // List<searchProducts_Result> objResult = null;
    
       searchProducts_Result outParam = new searchProducts_Result();
       using (var db = new SPWebEntities())
       {
          // by calling ToList() you execute the SP
          List<searchProducts_Result> objResult =
              db.searchProducts("asd", 2, 5, "15", nameParam).ToList();
          if (nameParam.Value != null)
             outParam.UserID = nameParam.Value.ToString();
          else
             outParam.UserID = "0";
          listobjs.Add(outParam);
          foreach (searchProducts_Result sr in objResult)
          {
             listobjs.Add(sr);
          }
       }
            
       return listobjs;
    }

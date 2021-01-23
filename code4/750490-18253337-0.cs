    // Ideally, change this to a more appropriate return type...
    private object GetValuesDB()
    {
       ......
       var result = from val in datacTx.TableA
                    where val.A == "AA" + "-" + "11" &&
                          val.B == "CC"
                    select val;
       return result.First();
    }
    
    ...
    public void MethodA()
    {
      var res = GetValuesDB();
      foreach (var propertyInfo in res.GetType().GetProperties())
      {
        var rez = propertyInfo.GetValue(res, null);
      }
    }

    public List<Map> GetAllMaps()
    {
        var Maps = new System.Collections.Generic.List<Map>();
        try
        {
             using (var mapEntities = new Model.MapEntities())
             {
                  var MyMaps= (from M in mapEntities.Maps
                                   orderby M.Description
                                   select M.MapID, M.Description);
                 foreach (var Map in MyMaps)
                 {
                       Maps.Add(Map);
                 }
              }
              return Maps;
          }
          catch (System.Exception Exc)
          {
              Log.Err(string.Format("Error: {0}", Exc));
              throw new System.Exception(Exc.ToString());
          }
    }

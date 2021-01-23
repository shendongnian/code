    public List<Vechicles> GetVehcileInformation(string VehicleType){
      var QueryString = Resources.Queries.AllVehicles;
      var parms = new List<SqlParameters>();
      parms.Add(new SqlParameter("VehicleType", VehicleType );
    
      using (var db = new MyEntities()){
          var stuff= db.SqlQuery<Vehicles>(QueryString, parms.ToArray());
        return stuff.ToList();
      }
     }

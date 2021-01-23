    public class CarType
    {
      public int CARID { get; set; }
      public string CARNAME{ get; set; }
    }
    var cars = new List<CarType>{new CarType { CARID = 1, CARNAME = "Volvo"}};
    
    var parameters = new DynamicParameters();
    parameters.AddTable("@Cars", "CarType", cars)
    
     var result = con.Query("InsertCars", parameters, commandType: CommandType.StoredProcedure);

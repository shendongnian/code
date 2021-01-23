    var Cache = new Cache()
    {
        Type = "Cache",
        Id = "Cache",
        ElementKeys = new List<string> {
            {"Parking", "House" };
        ElementValues = new List<JSONNode>{
            new Parking(){
            Type = "Parking",
            Id = "Parking",
            Cars = new List<Car>(){
                new Car(){
                Type="MyType1",
                Id = "3",
                Back = null},
                new Car(){
                Type="MyType2",
                Id = "3",
                Back = null}}
                }
        }
     };

    public class Car
    {
        public string Model { get; set; }
        public int Price { get; set; }
    }
    
    public void Foo()
    {
        string strSQL = "Select * From Cars";
    
        List<Car> cars = new List<Car>();
        //...initialize connection, Command, etc...
        while (reader.Read())
        {
            cars.Add(new Car {
                Model = reader["Model"] + "", 
                Price = (int)reader["Price"]
            });
        }
        //...send cars.ToArray() over to client...
    }

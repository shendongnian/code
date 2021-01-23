    class Program
    {
        static void Main(string[] args)
        {
            DataTable CarsImportedFromFile = new DataTable();
            // load data in from CSV
            List<Car> Cars = new List<Car>();
            foreach (DataRow CurrentRow in CarsImportedFromFile.Rows)
            {
                Car MyCar = new Car();
                MyCar.Model = CurrentRow["Model"].ToString();
                MyCar.Color = CurrentRow["Color"].ToString();
                Cars.Add(MyCar);
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
    }

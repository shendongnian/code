    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Model
    {
        public int SelectedId { get; set; }
        public IEnumerable<Vehicle> Items { get; set; }
    }

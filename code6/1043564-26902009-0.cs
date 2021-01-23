    public class MainViewModel
    {
        public List<People> PeopleList { get; set; }
        public MainViewModel() { GenerateList(); }
        public void GenerateList()
        {
            PeopleList = new List<People>();
            TravelNode car = new TravelNode { VehicleName = "Car" };
            TravelNode bus = new TravelNode { VehicleName = "Bus" };
            TravelNode bike = new TravelNode { VehicleName = "Bike" };
            TravelNode train = new TravelNode { VehicleName = "Train" };
            People john = new People();
            john.Name = "John";
            john.TravelNodes = new List<TravelNode>();
            john.TravelNodes.Add(car); john.TravelNodes.Add(bike);
            People jerry=new People();
            jerry.Name="Jerry";
            jerry.TravelNodes=new List<TravelNode>();
            jerry.TravelNodes.Add(bus); jerry.TravelNodes.Add(train);
            PeopleList.Add(john); PeopleList.Add(jerry);
        }
    }
    public class People
    {
        public List<TravelNode> TravelNodes { get; set; }
        public string Name { get; set; }
    }
    public class TravelNode
    {
        public string VehicleName { get; set; }
    }

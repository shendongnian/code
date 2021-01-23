    class Program
    {
        static void Main(string[] args)
        {
            VehicleList list = new VehicleList()
            {
                new Vehicle{VehicleRegistration = "b"},
                new Vehicle{VehicleRegistration = "a"}
            };
            list.mySort(x => x.VehicleRegistration);
            foreach (var item in list)
            {
                Console.WriteLine(item.VehicleRegistration);
            }
        }
    }
    class VehicleList : List<Vehicle>
    {
        public void mySort(Func<Vehicle,IComparable> theThingToCompare)
        {
            _theThingToCompare = theThingToCompare;
            this.Sort(Compare);
        }
        private static Func<Vehicle,IComparable> _theThingToCompare;
        private static int Compare(Vehicle v1, Vehicle v2)
        {
            return _theThingToCompare(v1).CompareTo(_theThingToCompare(v1))
        }
    }

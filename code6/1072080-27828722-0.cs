    public class Plant : IEquatable<Plant>
    {
        public string Name { get; set; }
        public string Weight { get; set; }
        public override bool Equals(object obj)
        {
            var other=obj as Plant;
            if(other!=null)
            {
                return Equals(other);
            }
            return false;
        }
        public bool Equals(Plant other)
        {
            Debug.WriteLine("Checking Equality Between {0} And {1}", Name, other.Name);
            return Name.Equals(other.Name);
        }
    }
    public class Fruit : Plant
    {
        public string Seeds { get; set; }
    }
    public class Veg : Plant
    {
        public string SavoryLevel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Fruit> fruits=new List<Fruit>() { 
                new Fruit() { Name="apple", Weight = "2", Seeds="5" },
                new Fruit() { Name="banana", Weight="1", Seeds="30" }
            };
            List<Veg> veggies=new List<Veg>() {
                new Veg() { Name = "carrot", Weight="3", SavoryLevel="7" },
                new Veg() { Name = "potato", Weight="5", SavoryLevel="1" }
            };
            var equal=fruits.Cast<Plant>().SequenceEqual(veggies);
        }
    }

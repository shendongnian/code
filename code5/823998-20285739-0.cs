    namespace TestCase
    {
      public class CarNames : IEnumerable
      {
        public IEnumerable AutoCompletions = new List<Car>
            {
                new Car { Name = "Astra" },
                new Car { Name = "Audi" },
                new Car { Name = "Avant" },
                new Car { Name = "Bugatti" },
                new Car { Name = "Bentley" },
                new Car { Name = "BMW" },
                new Car { Name = "Bond" },
                new Car { Name = "Buckler" },
                new Car { Name = "Burney" },
                new Car { Name = "Chrysler " },
                new Car { Name = "Citroën" },
                new Car { Name = "Crossley" },
            };
        public IEnumerator GetEnumerator()
        {
            return AutoCompletions.GetEnumerator();
        }
    }
    public class Car
    {
        public string Name { get; set; }
    }

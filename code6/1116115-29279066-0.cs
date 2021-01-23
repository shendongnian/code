    class Program
    {
        static void Main(string[] args)
        {
            var iceCream = new IceCream(Flavor.Chocolate | Flavor.Vanilla);
            Console.WriteLine("{0} has {1} flavors", 
                iceCream.Flavors, iceCream.FlavorCount);
        }
    }
    [Flags]
    enum Flavor
    {
        Chocolate   = 1 << 0,
        Vanilla     = 1 << 1, 
        Strawberry  = 1 << 2
    };
    class IceCream
    {
        public Flavor Flavors { get; private set; }
        public int FlavorCount
        {
            get
            {
                return Enum.GetValues(typeof(Flavor)).Cast<Flavor>()
                           .Count(item => (item & this.Flavors) != 0);
            }
        }
        public IceCream() { }
        public IceCream(Flavor flavors)
        {
            this.Flavors = flavors;
        }
    }

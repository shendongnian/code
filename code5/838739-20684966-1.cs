     class Program
    {
        static void Main()
        {
            var flyingThings = new ThingsThatFlyCollection();
            var bird = new Bird();
            var bird2 = new Bird();
            var plane = new Plane();
            flyingThings.Add(bird);
            flyingThings.Add(bird2);
            flyingThings.Add(plane);
            Console.WriteLine(flyingThings.GetItemWithCast<string>(0).GetMark());
            Console.WriteLine(flyingThings.GetItemWithCast<string>(1).GetMark());
            Console.WriteLine(flyingThings.GetItemWithCast<int>(2).GetMark());
            foreach (var item in flyingThings.GetItemsWithCast<int>()) 
            {
                Console.WriteLine(item.GetMark());
            }
            foreach (var item in flyingThings.GetItemsWithCast<string>())
            {
                Console.WriteLine(item.GetMark());
            }
            foreach (var item in flyingThings.GetItemsByType<Bird>())
            {
                Console.WriteLine(item.GetMark());
            }
            Console.ReadKey();
        }
    }
    public interface IFly
    {
        object GetMark();
    }
    public interface IFly<TMark> : IFly
    {
        new TMark GetMark();
    }
    class Plane : IFly<int>
    {
        public int GetMark() { return 123; }
        object IFly.GetMark() { return this.GetMark(); }
    }
    class Bird : IFly<string>
    {
        public string GetMark() { return "Bird"; }
        object IFly.GetMark() { return this.GetMark(); }
    }
    class ThingsThatFlyCollection : Collection<IFly>
    {
        public IFly<TMark> GetItemWithCast<TMark>(int index)
        {
            var f = this[index] as IFly<TMark>;
            if (f == null) { throw new InvalidCastException(); }
            return f;
        }
        public IEnumerable<IFly<TMark>> GetItemsWithCast<TMark>()
        {
            var items = this.Where(p => p is IFly<TMark>).Cast<IFly<TMark>>();
            return items;
        }
        public IEnumerable<TFlyer> GetItemsByType<TFlyer>() where TFlyer : IFly 
        {
            var items = this.Where(p => p.GetType() == typeof(TFlyer)).Cast<TFlyer>();
            return items;
        }
    }

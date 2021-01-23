    abstract class Equippable : Item {}    
    
    abstract class Armor : Equippable
    {
        // every armor has a Defence property
        public abstract int Defence { get; }
        // the base comparison logic of two armors
        public override void CompareWith(Item item)
        {
            Console.WriteLine("{0} or {1}", ((Armor)item).Defence, this.Defence);
        }
    }
    class Chest : Armor
    {
        // if you want for chests to be comared with chests only:
        public override bool CanCompareWith(Item item)
        {
            return item is Chest;
        }
        public override int Defence
        {
            get { return 10; }
        }
    }
    class Helmet : Armor
    {
        public override bool CanCompareWith(Item item)
        {
            return item is Helmet;
        }
        public override int Defence
        {
            get { return 5; }
        }
    }

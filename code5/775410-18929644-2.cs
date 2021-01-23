    abstract class Weapon : Equippable
    {
        // every weapon has Attack property
        public abstract int Attack { get; }
        // the base comparison logc of two weapons
        public override void CompareWith(Item item)
        {
            Console.WriteLine("{0} or {1}", ((Weapon)item).Attack, this.Attack);
        }
    }
    class Melee : Weapon
    {
        public override bool CanCompareWith(Item item)
        {
            return item is Melee;
        }
        public override int Attack
        {
            get { return 20; }
        }
    }
    class Ranged : Weapon
    {
        public override bool CanCompareWith(Item item)
        {
            return item is Ranged;
        }
        public override int Attack
        {
            get { return 25; }
        }
    }

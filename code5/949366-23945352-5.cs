    public abstract class Animal
    {
        //The zoo code of this animal. 
        public abstract int ZooCode { get; }
        //other things specific to an animal. 
    }
    public class Elephant : Animal
    {
        //An Elephant has a zoo code of 1
        public override int ZooCode { get { return 1; } }
    }
    public class ZooKeeperBase
    { }
    public abstract class ZooKeeper<T> : ZooKeeperBase
    where T : Animal
    {
        //Tend to our animals needs
        public abstract void CareForAnimal(T animal);
    }
    public class ElephantKeeper : ZooKeeper<Elephant>
    {
        public override void CareForAnimal(Elephant animal)
        {
            Console.WriteLine("Hi elephant! take some peanuts.");
        }
    }
    public class ZooKeeperManager
    {
        /// <summary>
        /// All of the ZooKeepers, mapped to the ZooCode of the animal they 
        /// care for. 
        /// </summary>
        private List<ZooKeeperBase> _zooKeepers = new List<ZooKeeperBase>();
        /// <summary>
        /// Called when we hire a new zoo keeper. 
        /// </summary>
        public void RegisterZooKeeper(ZooKeeperBase newbie)
        {
            //data validation, etc...
            //store our new zookeeper. 
            _zooKeepers.Add(newbie);
        }
        public void CareForAnimal<T>(T animal) where T : Animal
        {
            //How do I find the Zoo Keeper that Cares for this Animal?? 
            //A List definitely isn't what I want.. I won't have o(1) Lookup, plus how do I know
            //Which concrete Animal that ZooKeeper cares about?
            foreach (ZooKeeperBase keeper in _zooKeepers)
            {
                var thisKeeper = keeper as ZooKeeper<T>;
                if (thisKeeper != null)
                {
                    thisKeeper.CareForAnimal(animal);
                    return;
                
                }
            }
        }
    }
    public static class ZooKeepingSystemTest
    { 
    
        public static void KeepIt()
        {
            ZooKeeperManager manager = new ZooKeeperManager();
            ElephantKeeper keeper = new ElephantKeeper();
            manager.RegisterZooKeeper(keeper);
            manager.CareForAnimal(new Elephant());
        }
    
    }

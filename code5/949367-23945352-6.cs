    public class ZooKeeperManager
    {
        /// <summary>
        /// All of the ZooKeepers, mapped to the Animal's full class name they
        /// care for. 
        /// </summary>
        private Dictionary<string, List<ZooKeeperBase>> _zooKeepers = new Dictionary<string, List<ZooKeeperBase>>();
        /// <summary>
        /// Called when we hire a new zoo keeper. 
        /// </summary>
        public void RegisterZooKeeper<T>(ZooKeeper<T> newbie) where T : Animal
        {
            //data validation, etc...
            var type = typeof(T);
            List<ZooKeeperBase> keeperPool = null;
            if (_zooKeepers.ContainsKey(type.FullName))
                keeperPool = _zooKeepers[type.FullName];
            else
            {
                keeperPool = new List<ZooKeeperBase>();
                _zooKeepers.Add(type.FullName, keeperPool);
            }
            //store our new zookeeper. 
            keeperPool.Add(newbie);
        }
        public void CareForAnimal<T>(T animal) where T : Animal
        {
            var type = typeof(T);
            if (!_zooKeepers.ContainsKey(type.FullName))
                throw new Exception("We don't know how to care that animal!");
            Random rnd = new Random();
            ((ZooKeeper<T>)(_zooKeepers[type.FullName].OrderBy(k => rnd.NextDouble()).First())).CareForAnimal(animal); ;
        }
    }

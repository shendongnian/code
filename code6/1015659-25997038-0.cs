    public interface ISpawnableObject
    {
        int ThousandInOneProbability { get; }
    }
    public class SpawnGenerator<T> where T : ISpawnableObject
    {
        private class SpawnableObject
        {
            readonly T spawnable;
            readonly int minThreshold;
            readonly int maxThreshold;
            public SpawnableObject(T spawnable, int minThreshold)
            {
                this.spawnable = spawnable;
                this.minThreshold = minThreshold;
                this.maxThreshold = this.minThreshold + spawnable.ThousandInOneProbability;
            }
            public T Spawnable { get { return this.spawnable; } }
            public int MinThreshold { get { return this.minThreshold; } }
            public int MaxThreshold { get { return this.maxThreshold; } }
        }
        private List<SpawnableObject> spawnableObjects;
        private Random r;
        public SpawnGenerator(IEnumerable<T> objects, int seed)
        {
            r = new Random(seed);
            var totalProbability = 0;
            spawnableObjects = new List<SpawnableObject>();
            foreach (var o in objects)
            {
                var spawnable = new SpawnableObject(o, totalProbability);
                totalProbability += o.ThousandInOneProbability;
                spawnableObjects.Add(spawnable);
            }
            Debug.Assert(totalProbability <= 1000);
        }
        //Note that it can spawn null if probabilities dont add up to 1000
        public T Spawn()
        {
            var i = r.Next(0, 1000);
            retutn (from s in this.spawnableObjects
                    where (s.MaxThreshold > i && s.MinThreshold <= i)
                    select s.Spawnable).FirstOrDefault();
        }
    }

    public interface ISpawnable : ICloneable
    {
        int OneInThousandProbability { get; }
    }
    public class SpawnGenerator<T> where T : ISpawnable
    {
        private class SpawnableWrapper
        {
            readonly T spawnable;
            readonly int minThreshold;
            readonly int maxThreshold;
            public SpawnableWrapper(T spawnable, int minThreshold)
            {
                this.spawnable = spawnable;
                this.minThreshold = minThreshold;
                this.maxThreshold = this.minThreshold + spawnable.OneInThousandProbability;
            }
            public T Spawnable { get { return this.spawnable; } }
            public int MinThreshold { get { return this.minThreshold; } }
            public int MaxThreshold { get { return this.maxThreshold; } }
        }
        private ICollection<SpawnableWrapper> spawnableEntities;
        private Random r;
        public SpawnGenerator(IEnumerable<T> objects, int seed)
        {
            Debug.Assert(objects != null);
            r = new Random(seed);
            var totalProbability = 0;
            spawnableEntities = new List<SpawnableWrapper>();
            foreach (var o in objects)
            {
                var spawnable = new SpawnableWrapper(o, totalProbability);
                totalProbability += o.OneInThousandProbability;
                spawnableEntities.Add(spawnable);
            }
            Debug.Assert(totalProbability <= 1000);
        }
        //Note that it can spawn null (no spawn) if probabilities dont add up to 1000
        public T Spawn()
        {
            var i = r.Next(0, 1000);
            var retVal = (from s in this.spawnableEntities
                          where (s.MaxThreshold > i && s.MinThreshold <= i)
                          select s.Spawnable).FirstOrDefault();
            return retVal != null ? (T)retVal.Clone() : retVal;
        }
    }

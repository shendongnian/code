    public class Hasher
    {
        private readonly Dictionary<int, int> Hashes = new Dictionary<int, int>();
        public int Hash(int value)
        {
            int hash;
            if (!Hashes.TryGetValue(value, out hash))
            {
                hash = Hashes.Count;
                Hashes[value] = Hashes.Count;
            }
            return hash;
        }
    }

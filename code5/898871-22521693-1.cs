    public interface IKeyed
    {
        int ExtractKey();
    }
    struct Sha256_Long : IComparable<Sha256_Long>, IKeyed
    {
        private UInt64 _piece1;
        private UInt64 _piece2;
        private UInt64 _piece3;
        private UInt64 _piece4;
        public Sha256_Long(string hex)
        {
            if (hex.Length != 64)
            {
                throw new ArgumentException("Hex string must contain exactly 64 digits.");
            }
            UInt64[] pieces = new UInt64[4];
            for (int i = 0; i < 4; i++)
            {
                pieces[i] = UInt64.Parse(hex.Substring(i * 8, 1), NumberStyles.HexNumber);
            }
            _piece1 = pieces[0];
            _piece2 = pieces[1];
            _piece3 = pieces[2];
            _piece4 = pieces[3];
        }
        public Sha256_Long(byte[] bytes)
        {
            if (bytes.Length != 32)
            {
                throw new ArgumentException("Sha256 values must be exactly 32 bytes.");
            }
            _piece1 = BitConverter.ToUInt64(bytes, 0);
            _piece2 = BitConverter.ToUInt64(bytes, 8);
            _piece3 = BitConverter.ToUInt64(bytes, 16);
            _piece4 = BitConverter.ToUInt64(bytes, 24);
        }
        public override string ToString()
        {
            return String.Format("{0:X}{0:X}{0:X}{0:X}", _piece1, _piece2, _piece3, _piece4);
        }
        public int CompareTo(Sha256_Long other)
        {
            if (this._piece1 < other._piece1) return -1;
            if (this._piece1 > other._piece1) return 1;
            if (this._piece2 < other._piece2) return -1;
            if (this._piece2 > other._piece2) return 1;
            if (this._piece3 < other._piece3) return -1;
            if (this._piece3 > other._piece3) return 1;
            if (this._piece4 < other._piece4) return -1;
            if (this._piece4 > other._piece4) return 1;
            return 0;
        }
        //-------------------------------------------------------------------
        // Implementation of key extraction
        public const int KeyBits = 8;
        private static UInt64 _keyMask;
        private static int _shiftBits;
        static Sha256_Long()
        {
            _keyMask = 0;
            for (int i = 0; i < KeyBits; i++)
            {
                _keyMask |= (UInt64)1 << i;
            }
            _shiftBits = 64 - KeyBits;
        }
        public int ExtractKey()
        {
            UInt64 keyRaw = _piece1 & _keyMask;
            return (int)(keyRaw >> _shiftBits);
        }
    }
    class IndexedSet<T> where T : IComparable<T>, IKeyed
    {
        private T[][] _keyedSets;
        public IndexedSet(IEnumerable<T> source, int keyBits)
        {
            // Arrange elements into groups by key
            var keyedSetsInit = new Dictionary<int, List<T>>();
            foreach (T item in source)
            {
                int key = item.ExtractKey();
                List<T> vals;
                if (!keyedSetsInit.TryGetValue(key, out vals))
                {
                    vals = new List<T>();
                    keyedSetsInit.Add(key, vals);
                }
                vals.Add(item);
            }
            // Transform the above structure into a more efficient array-based structure
            int nKeys = 1 << keyBits;
            _keyedSets = new T[nKeys][];
            for (int key = 0; key < nKeys; key++)
            {
                List<T> vals;
                if (keyedSetsInit.TryGetValue(key, out vals))
                {
                    _keyedSets[key] = vals.OrderBy(x => x).ToArray();
                }
            }
        }
        public bool Contains(T item)
        {
            int key = item.ExtractKey();
            if (_keyedSets[key] == null)
            {
                return false;
            }
            else
            {
                return Search(item, _keyedSets[key]);
            }
        }
        private bool Search(T item, T[] set)
        {
            int first = 0;
            int last = set.Length - 1;
            while (first <= last)
            {
                int midpoint = (first + last) / 2;
                int cmp = item.CompareTo(set[midpoint]);
                if (cmp == 0)
                {
                    return true;
                }
                else if (cmp < 0)
                {
                    last = midpoint - 1;
                }
                else
                {
                    first = midpoint + 1;
                }
            }
            return false;
        }
    }
    class Program
    {
        //private const int NTestItems = 100 * 1000 * 1000;
        private const int NTestItems = 1 * 1000 * 1000;
        private static Sha256_Long RandomHash(Random rand)
        {
            var bytes = new byte[32];
            rand.NextBytes(bytes);
            return new Sha256_Long(bytes);
        }
        static IEnumerable<Sha256_Long> GenerateRandomHashes(
            Random rand, int nToGenerate)
        {
            for (int i = 0; i < nToGenerate; i++)
            {
                yield return RandomHash(rand);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Generating test set.");
            var rand = new Random();
            IndexedSet<Sha256_Long> set =
                new IndexedSet<Sha256_Long>(
                    GenerateRandomHashes(rand, NTestItems),
                    Sha256_Long.KeyBits);
            Console.WriteLine("Testing with random input.");
            int nFound = 0;
            int nItems = NTestItems;
            int waypointDistance = 100000;
            int waypoint = 0;
            for (int i = 0; i < nItems; i++)
            {
                if (++waypoint == waypointDistance)
                {
                    Console.WriteLine("Test lookups complete: " + (i + 1));
                    waypoint = 0;
                }
                var item = RandomHash(rand);
                nFound += set.Contains(item) ? 1 : 0;
            }
            Console.WriteLine("Testing complete.");
            Console.WriteLine(String.Format("Found: {0} / {0}", nFound, nItems));
            Console.ReadKey();
        }
    }

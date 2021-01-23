    public class IdentityEqualityComparer<T> : IEqualityComparer<T> where T : class
    {
        public int GetHashCode(T value)
        {
            return RuntimeHelpers.GetHashCode(value);
        }
        public bool Equals(T left, T right)
        {
            return left == right; // Reference identity comparison
        }
    }
    public class RefKeyType
    {
        public int ID { get; set; }
    }
    class Program
    {
        public static void Main()
        {
            var refDictionary = new Dictionary<RefKeyType, int>(1000000, new IdentityEqualityComparer<RefKeyType>());
            var testDictionary = new Dictionary<RefKeyType, int>(1000000, new IdentityEqualityComparer<RefKeyType>());
            var store = new Dictionary<RefKeyType, int>(1000000);
            for (var i = 0; i < 1000000; i++)
            {
                var key = new RefKeyType() {ID = i};
                refDictionary[key] = i;
                //Load the test dictionary if I is divisible by 2
                if (i%2 == 0)
                {
                    testDictionary[key] = i;
                }
            }
            foreach (var key in refDictionary.Keys)
            {
                int val;
                if (!testDictionary.TryGetValue(key, out val))
                {
                    store[key] = val;
                }
            }
            Console.WriteLine("Master dictionary has " + refDictionary.Count);
            Console.WriteLine("Test dictionary has " + testDictionary.Count);
            Console.WriteLine("Store dictionary has " + store.Count);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

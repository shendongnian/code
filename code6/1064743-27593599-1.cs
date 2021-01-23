    public struct IntKey
    {
        private readonly int first;
        private readonly int second;
        public IntKey(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
        public bool Equals(IntKey other)
        {
            return this.first == other.first && this.second == other.second;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is IntKey && Equals((IntKey) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.first*397) ^ this.second;
            }
        }
    }
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void Test()
        {
            var dictionary = new Dictionary<IntKey, string>();
            for (int j = 0; j < 3; j++)
            {
                dictionary.Clear();
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < 1000000; i++)
                {
                    dictionary.Add(new IntKey(i, i), "asdf");
                }
                Console.WriteLine(watch.ElapsedMilliseconds);
                watch.Restart();
                for (int i = 0; i < 1000000; i++)
                {
                    var value = dictionary[new IntKey(i, i)];
                }
                Console.WriteLine(watch.ElapsedMilliseconds);
            }
        }
    }

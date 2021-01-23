    class Program
        {
            static void Main(string[] args)
            {
                Collection collect = new Collection(new string[]{"LOL1","LOL2"});
                foreach (string col in collect)
                {
                    Console.WriteLine(col + "\n");
                }
                Console.ReadKey();
            }
        }
    
        public class Collection : IEnumerable
        {
            private Collection(){}
            public string[] CollectedCollection { get; set; }
            public Collection(string[] ArrayCollection)
            {
                CollectedCollection = ArrayCollection;
            }
    
            public IEnumerator GetEnumerator()
            {
                return this.CollectedCollection.GetEnumerator();
            }
        }

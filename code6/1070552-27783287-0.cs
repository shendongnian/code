    public class ListItem
    {
        public ListItem(string key) { Key=key; }
        public string Key { get; private set; }
        // ...
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list=new List<ListItem>() 
            {
                new ListItem("A"),
                new ListItem("B"),
                new ListItem("C"),
                new ListItem("D"),
                new ListItem("A"),
                new ListItem("B"),
                new ListItem("E"),
                new ListItem("F"),
                new ListItem("G"),
            };
            var sublists=Partition(list, 3);
            // 0: A, A, C
            // 1: B, B, D
            // 3: E, F, G
        }
        static List<List<ListItem>> Partition(IEnumerable<ListItem> list, int batchSize)
        {
            // create empty lists of batches
            var partitions=new List<List<ListItem>>();
            // group items with same key together
            var lookup=list.ToLookup((item) => item.Key);
            foreach(var group in lookup)
            {
                // Get array of same items (called a flock)
                ListItem[] flock=lookup[group.Key].ToArray();
                if(flock.Length>batchSize)
                {
                    throw new ArgumentException("Batch Size is too small for grouping", "batchSize");
                }
                //Find first batch with available space from existing ones
                var batch=partitions.FirstOrDefault((part) => (batchSize-part.Count)>=flock.Length);
                if(batch!=null)
                {
                    batch.AddRange(flock);
                }
                else // otherwise create a new batch
                {
                    partitions.Add(new List<ListItem>(flock));
                }
            }
            return partitions;
        }
    }

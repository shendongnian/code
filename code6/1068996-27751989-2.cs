    public partial class MyDbContext
    {
        public IEnumerable<ATable> GetElements(IEnumerable<long> hugeList, int chunkSize = 100)
        {
            foreach (var chunk in hugeList.Chunk(chunkSize))
            {
                var q = ATables.Where(a => chunk.Contains(a.Name));
                foreach (var item in q)
                {
                    yield return item;
                }
            }
        }
    }

    public class GeneratorIncrementalLoadingClass: IncrementalLoadingBase
    {
        private int _numLeft;
        private Func<int, Task<int>> _loadMore;
        public GeneratorIncrementalLoadingClass(Func<int, Task<int>> loadMore, Func<int, T> generator)
        {
            _loadMore = loadMore;
            _generator = generator;
        }
        protected async override Task<IList<object>> LoadMoreItemsOverrideAsync(System.Threading.CancellationToken c, uint count)
        {
            // If count is greater than the max size that we know, load the difference first
            List<object> returnList = new List<object>();
            if(count > 20)
            {
                var tempList = await LoadMoreItemsOverrideAsync(c, count);
                returnList.AddRange(tempList);
            }
            // Find out if there are enough left that it's asking for
            uint toGenerate = System.Math.Min(count, _numLeft);
            // Wait for load
            _numLeft = await _loadMore(toGenerate);
            // This code simply generates
            var values = from j in Enumerable.Range((int)_count, (int)toGenerate)
                         select (object)_generator(j);
            _count += toGenerate;
            return values.ToList().AddRange(tempList);
        }
        protected override bool HasMoreItemsOverride()
        {
            return _numLeft > 0;
        }
        Func<int, T> _generator;
        uint _count = 0;
        uint _maxCount;
    }

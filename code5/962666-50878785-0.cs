        [GlobalSetup]
        public virtual void Setup()
        {
            data = new T[N];
            indexes = new int[N];
            for (var cc = 0; cc < N; cc++)
            {
                data[cc] = GetRandom();
                indexes[cc] = cc;
            }
        }
        // Clone is nessesary as Array.Sort is done in place, ie the next call will be incorrectly given a pre-sorted list
        private T[] GetTestData() => (T[]) data.Clone();
        private int[] GetTestDataIndex() => (int[])indexes.Clone();
        [Benchmark]
        public virtual void Sort()
        {
            Array.Sort(GetTestData());
        }
        [Benchmark]
        public virtual void SortMaintainIndex()
        {
            Array.Sort(GetTestData(), GetTestDataIndex());
        }
        [Benchmark]
        public virtual void SortWithLinq()
        {
            int cc = 0;
            var withIndex = GetTestData()
                      .Select(x => (cc++, x))
                      .OrderBy(x => x.x)
                      .ToArray();
        }

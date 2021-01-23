    static CustomEnumerable SampleIteratorHard(int start, int end)
    {
        return new CustomEnumerable(start, end);
    }
    class CustomEnumerable
    {
        private readonly int start, end;
        public CustomEnumerable(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
        public CustomIterator GetEnumerator()
        {
            return new CustomIterator(start, end);
        }
    }
    class CustomIterator
    {
        private readonly int start, end;
        int i, state, value;
        public CustomIterator(int start, int end)
        {
            this.start = start;
            this.end = end;
            start = 0;
        }
        public bool MoveNext()
        {
            if (state == 2) return false;
            if (state == 0)
            {
                i = start - 1; // to leave space for the ++
                state = 1;
            }
            if (state == 1)
            {
                i++;
                if (i <= end)
                {
                    value = i;
                    return true;
                }
            }
            state = 2;
            return false;
        }
        public int Current {  get {  return value; } }
    }

    private class PriceRangeFactory<T>
    {
        public PriceRangeFactory(T[] rangeCutoffs)
        {
            _RangeCutoffs = rangeCutoffs;
        }
        private T[] _RangeCutoffs;
        public PriceRange<T> Map(T price)
        {
            var index = Array.BinarySearch(_RangeCutoffs, price);
            // Assume that the _RangeCutoffs that we have fully cover all possible values for T.
            if (index < 0) index = ~index;
            return new PriceRange<T>() { Min = _RangeCutoffs[index - 1], Max = _RangeCutoffs[index] };
        }
    }

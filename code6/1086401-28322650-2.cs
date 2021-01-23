        public delegate bool MyTest<in T>(T previousValue, T currentValue);
        IEnumerable<T> MyFunction<T>(IEnumerable<T> input, MyTest<T> test)
        {
            var isFirst = true;
            var previousValue = default(T); // will be rewritten immediately.
            foreach (var value in input)
            {
                if (isFirst || test(previousValue, value))
                {
                    isFirst = false;
                    previousValue = value;
                    yield return value;
                }
            }
        }

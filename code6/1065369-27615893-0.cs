        public IEnumerable<long> InfiniteTribonacciSequence()
        {
            long a = 0, b = 1, c = 1;
            long nextTerm;
            yield return a;
            yield return b;
            yield return c;
            while (true)
            {
                nextTerm = a + b + c;
                yield return nextTerm;
                a = b;
                b = c;
                c = nextTerm;
            }
        }

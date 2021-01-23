        public static IEnumerable<TResult> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource input in source)
            {
                TResult result;
                bool wasSuccesful = false;
                try
                {
                    result = selector(input);
                    wasSuccesful = true;
                }
                catch { }
                if (wasSuccesful)
                {
                    yield return result;
                }
            }
        }

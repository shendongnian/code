    static class Extensions
    {
        public delegate bool TryParseDelegate<TSource>(string s, out TSource source);
    
        public static IEnumerable<TResult> WhereParsed<TSource, TResult>(
                                                   this IEnumerable<TSource> source,
                                                   TryParseDelegate<TResult> tryParse)
        {
            // check arguments against null first
            foreach (var item in source)
            {
                TResult result;
                if (tryParse(item.ToString(), out result))
                {
                    yield return result;
                }
            }
        } 
    }

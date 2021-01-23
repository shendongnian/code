    static class Extensions
    {
        public delegate bool TryParseDelegate<TSource>(string s, out TSource source);
    
        public static IEnumerable<TResult> WhereParsed<TSource, TResult>(
                                                   this IEnumerable<TSource> source,
                                                   TryParseDelegate<TResult> tryParse)
        {
       
             // TODO: check arguments against null first
            foreach (var item in source)
            {
                TResult result;
                if (tryParse(item != null ? item.ToString() : null, out result))
                {
                    yield return result;
                }
            }
        }
    } 

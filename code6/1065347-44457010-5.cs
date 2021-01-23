    public static class EnumerableExt
    {
        // We use the `Skip` name because its implied behaviour equals the `Skip` and `SkipWhile` implementations
        public static IEnumerable<TSource> SkipExceptions<TSource>(this IEnumerable<TSource> source)
        {
            // We use the enumerator to be able to catch exceptions when enumerating the source
            using (var enumerator = source.GetEnumerator())
            {
                // We use a true loop with a break because enumerator.MoveNext can throw the Exception we need to handle
                while (true)
                {
                    var exceptionCaught = false;
                    var currentElement = default(TSource);
                    try
                    {
                        if (!enumerator.MoveNext())
                        {
                            // We've finished enumerating. Break to exit the while loop                            
                            break;
                        }
                        currentElement = enumerator.Current;
                    }
                    catch
                    {
                        // Ignore this exception and skip this item.
                        exceptionCaught = true;
                    }
                    // Skip this item if we caught an exception. Otherwise return the current element.
                    if (exceptionCaught) continue;
                    
                    yield return currentElement;
                }
            }
        }
    }

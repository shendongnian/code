    public static IEnumerable<B> MapPairs<A, B>(this IEnumerable<A> sequence, 
                                                     Func<A, A, B> mapper)
        {
            var enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var first = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    var second = enumerator.Current;
                    yield return mapper(first, second);
                }
                else
                {
                    //What should we do with left over?
                }
            }
        }

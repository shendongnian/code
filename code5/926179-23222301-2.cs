    public static class MyEnumerable
    {
        public static IEnumerable<T> Smash<T>(this IEnumerable<T> one, IEnumerable<T> two)
        {
            using (IEnumerator<T> enumeratorOne = one.GetEnumerator(), 
                                  enumeratorTwo = two.GetEnumerator())
            {
                bool twoFinished = false;
    
                while (enumeratorOne.MoveNext())
                {
                    yield return enumeratorOne.Current;
    
                    if (!twoFinished && enumeratorTwo.MoveNext())
                    {
                        yield return enumeratorTwo.Current;
                    }
                }
    
                if (!twoFinished)
                {
                    while (enumeratorTwo.MoveNext())
                    {
                        yield return enumeratorTwo.Current;
                    }
                }
            }
        }
    }

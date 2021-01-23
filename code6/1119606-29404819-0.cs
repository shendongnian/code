    public static IEnumerable<KeyValuePair<K, V>> MergeSortedLists<K, V>(
        SortedList<K, V> l1, 
        SortedList<K, V> l2)
        where K : IComparable
        where V : IComparable
    {
        using (var l1Iter = l1.GetEnumerator())
        using (var l2Iter = l2.GetEnumerator())
        {
            var morel1 = l1Iter.MoveNext();
            var morel2 = l2Iter.MoveNext();
            while (morel1 || morel2)
            {
                if (!morel1)
                {
                    yield return l2Iter.Current;
                    morel2 = l2Iter.MoveNext();
                }
                else if (!morel2)
                {
                    yield return l1Iter.Current;
                    morel1 = l1Iter.MoveNext();
                }
                else 
                {
                    var cmp = l1.Comparer.Compare(l1Iter.Current.Key, l2Iter.Current.Key);
                    if (cmp < 0)
                    {
                        yield return l1Iter.Current;
                        morel1 = l1Iter.MoveNext();
                    }
                    else if (cmp > 0)
                    {
                        yield return l2Iter.Current;
                        morel2 = l2Iter.MoveNext();
                    }
                    else // keys equal: use value to break tie.
                    {
                        if (l1Iter.Current.Value.CompareTo(l1Iter.Current.Value) <= 0)
                            yield return l1Iter.Current;
                        else
                            yield return l2Iter.Current;
                        // or if l1 takes precedence, replace above 4 lines with:
                        // yield return l1Iter.Current;
                        morel1 = l1Iter.MoveNext();
                        morel2 = l2Iter.MoveNext();
                    }
                }
            }
        }
    }

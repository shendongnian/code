    public static bool IsOrdered<T>(this IEnumerable<T> source, IComparer<T> comparer = null)
    {
        return source.IsOrdered(OrderByDirection.Ascending, comparer);
    }
    
    public static bool IsOrdered<T>(this IEnumerable<T> source, OrderByDirection direction, IComparer<T> comparer = null)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
    
        if (comparer == null)
        {
            comparer = Comparer<T>.Default;
        }
    
        int d = direction == OrderByDirection.Ascending ? 1 : -1;
    
        Func<T, T, int> compareFunc= (i1, i2) => d * comparer.Compare(i1, i2);
        return IsOrderedImpl(source, compareFunc);
    }
    
    public static bool IsOrdered<T>(this IEnumerable<T> source, Func<T, T, int> compareFunc)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (compareFunc == null)
        {
            throw new ArgumentNullException(nameof(compareFunc));
        }
    
        return IsOrderedImpl(source, compareFunc);
    }
    
    private static bool IsOrderedImpl<T>(this IEnumerable<T> source, Func<T, T, int> compareFunc)
    {
        T prevItem = default(T);
        int i = 0;
        foreach (T item in source)
        {
            if (i == 0)
            {
                prevItem = item;
            }
            else
            {
                if (compareFunc(prevItem, item) > 0)
                {
                    return false;
                }
    
                prevItem = item;
            }
    
            ++i;
        }
    
        return true;
    }
    [TestMethod]
    public void TestIsOrdered01()
    {
        Assert.IsTrue(Enumerable.Range(1, 10).IsOrdered());
        Assert.IsFalse(Enumerable.Range(1, 10).Reverse().IsOrdered());
        Assert.IsTrue(Enumerable.Range(1, 10).IsOrdered(OrderByDirection.Ascending));
        Assert.IsFalse(Enumerable.Range(1, 10).IsOrdered(OrderByDirection.Descending));
        Assert.IsFalse(Enumerable.Range(1, 10).Reverse().IsOrdered(OrderByDirection.Ascending));
        Assert.IsTrue(Enumerable.Range(1, 10).Reverse().IsOrdered(OrderByDirection.Descending));
    }

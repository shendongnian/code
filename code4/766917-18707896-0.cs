    public static IEnumerable<TResult> ZipAll<T, TResult>(this IEnumerable<T> list1,
                                                               IEnumerable<T> list2,
                                                               Func<T, T, TResult> zipper,
                                                               T defaultValue = default(T))
    {
        using (var enum1 = list1.GetEnumerator())
        {
            using (var enum2 = list2.GetEnumerator())
            {
                bool valid1, valid2;
                do
                {
                    valid1 = enum1.MoveNext();
                    valid2 = enum2.MoveNext();
                    if (valid1 || valid2)
                    {
                        var item1 = valid1 ? enum1.Current : defaultValue;
                        var item2 = valid2 ? enum2.Current : defaultValue;
                        yield return zipper(item1, item2);
                    }
                }
                while (valid1 || valid2);
            }
        }
    }

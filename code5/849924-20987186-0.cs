    static bool Test<T>(object obj1, object obj2)
    {
        List<T> list1 = obj1 as List<T>;
        List<T> list2 = obj2 as List<T>;
        return list1 != null && list2 != null && list1.Count == list2.Count;
    }
    ...
    bool result = Test<int>(Enumerable.Range(0, 5).ToList(), Enumerable.Range(0, 5).ToList());

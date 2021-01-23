    private static void Main(string[] args)
    {
        var list1 = new List<int>(new[] { 1, 2, 3, 4, 5 });
        var list2 = new List<string>(new[] { "foo1", "foo2", "foo3", "foo4", "foo5" });
        var list3 = new List<bool>(new[] {true, false, true, true, false});
        var dt = MakeDataTable(list1, list2, list3);
        Console.ReadLine();
    }
    private static DataTable MakeDataTable(params IEnumerable[] lists)
    {
        var dt = new DataTable();
        for (var i = 0; i < lists.Length; i++)
        {
            dt.Columns.Add("column" + i);
        }
        foreach (var data in CombineList(lists))
        {
            dt.Rows.Add(data);
        }
        return dt;
    }
    private static IEnumerable<object[]> CombineList(params IEnumerable[] lists)
    {
        var enumerators = lists.Select(l=>l.GetEnumerator()).ToArray();
        while (enumerators.All(e => e.MoveNext()))
        {
            var yieldData= new object[lists.Length];
            for (var i = 0; i < lists.Length; i++)
            {
                yieldData[i] = enumerators[i].Current;
            }
            yield return yieldData;
        }
    }

    int[] data = { 1, 2, 5, 7, 8, 9 };
    var result = data.Aggregate(new List<List<int>>(), (list, item) =>
    {
        List<int> previousList = list.Count > 0 ? list[list.Count - 1] : null;
        if (previousList != null && item == previousList[previousList.Count - 1] + 1)
        {
            previousList.Add(item);
        }
        else
        {
            list.Add(new List<int> { item });
        }
        return list;
    });
    foreach (List<int> list in result)
    {
        Console.WriteLine("Sequence: " + string.Join(", ", list));
    }

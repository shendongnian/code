    List<string> stringList = new List<string>
        {
            "ABCDEF",
            "DEF",
            "GHIAAAAAAAAAAAAAA",
            "SOMETHNG LONGER THAN 20 characters",
        };
    List<double> doubleList = new List<double>
        {
            1d,
            2,
            3,
            4
        };
    List<string> combined = new List<string>();
    int count = stringList.Count >= doubleList.Count ? stringList.Count : doubleList.Count;
    for (int i = 0; i < count; i++)
    {
        string firstColumn = stringList.Count <= i ? "" : stringList[i];
        string secondColumn = doubleList.Count <= i ? "" : doubleList[i].ToString();
        if (firstColumn.Length > 20)
        {
            //truncate rest of the values
            firstColumn = firstColumn.Substring(0, 20);
        }
        else
        {
            firstColumn = firstColumn + new string(' ', 20 - firstColumn.Length);
        }
        combined.Add(string.Format("{0} {1}", firstColumn, secondColumn));
    }
    File.WriteAllLines("yourFilePath.csv", combined);

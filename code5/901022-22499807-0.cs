    int[] table1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
    int[] tableMaster = new int[] { 1, 2, 2, 4, 4, 9 };
    int[] tableChild = (from t in table1
                        where !tableMaster.Contains(t)
                        select t).ToArray();

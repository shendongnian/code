    Excel.PivotTables pivotTables1 =
       (Excel.PivotTables)ws.PivotTables(Type.Missing);
    if (pivotTables1.Count > 0)
    {
        for (int j = 1; j <= pivotTables1.Count; j++)
    }

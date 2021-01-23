    public static IEnumerable<DataTable> EnumerateRowsInBatches(DataTable table,
                                                                int batchSize)
    {
        int rowCount = table.Rows.Count;
        int batchIndex = 0;
        DataTable result = table.Clone(); // This will not change, avoid recreate it
        while (batchIndex * batchSize < rowCount)
        {
            result.Rows.Clear(); // Reuse that DataTable, clear previous results
            int batchStart = batchIndex * batchSize;
            int batchLimit = (batchIndex + 1) * batchSize;
            if (rowCount < batchLimit)
                batchLimit = rowCount;
            for (int i = batchStart; i < batchLimit; i++)
                result.Rows.Add(table.Rows[i].ItemArray); // Avoid ImportRow
            batchIndex++;
            yield return result;
        }
    }

    public void ReflectRowsToTable(DataTable sourceTable, DataTable targetTable, Dictionary<string, List<string>> reflectedColumnsMap)
    {
        foreach (DataRow originalRow in sourceTable.Rows)
        {
            DataRow newRow = targetTable.NewRow();
    
            foreach (KeyValuePair<string, List<string>> keyValue in reflectedColumnsMap)
            {
                foreach (string targetColumn in keyValue.Value)
                    newRow[targetColumn] = originalRow[keyValue.Key];
            }
    
            sourceToTargetRowMap.Add(originalRow, newRow);
            targetTable.Rows.Add(newRow);
        }
    }

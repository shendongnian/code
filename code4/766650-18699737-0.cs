    public IEnumerable<AppServices.NotificationData> GetUpdates(DataRow currentRow, DataRow updatedRow)
    {
        if (currentRow.ItemArray.SequenceEqual(updatedRow)) yield break;
        
        var length = currentRow.ItemArray.Length;
        for(var i = 0; i < length; i++)
        {
            var currentCol = currentRow[i];
            var updatedCol = updatedRow[i];
            
            if (currentCol == null && updatedCol == null) continue;
            else if (currentCol == null && updatedCol != null) continue;
            else if (currentCol.Equals(updatedCol)) continue;
            
            yield return new AppServices.NotificationData
                         {
                            Key = updatedRow.Table.Columns[i].ColumnName,
                            Value = Convert.ToString(updatedCol)
                         };
        }
    }

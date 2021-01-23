    currentRow.ItemArray
        .Select((o, i) => new { Row = o; Index = i; })
        .Where(r => (r.Row == null && updatedRow[r.Index] != null)
            || (r.Row != null && updatedRow[r.Index] != null && !r.Row.Equals(updatedRow[r.Index]))
        .Select(r => new NotificationData
            {
                Key = updatedRow.Table.Columns[r.Index].ColumnName,
                Value = Convert.ToString(updatedRow[r.Index])
            }
        )
        .ToList();

    if (currentRow.ItemArray.SequenceEqual(updatedRow)) { return; }
    var updates = currentRow.ItemArray
        .Select((o, i) =>
        {
            if (o == null && updatedRow[i] == null || o.Equals(updatedRow[i])) { return null; }
            else return new AppServices.NotificationData
            {
                Key = updatedRow.Table.Columns[i].ColumnName,
                Value = Convert.ToString(updatedRow[i])
            };
        }).Where(o => o != null).ToList();

    var updates = currentRow.ItemArray
        .Select((o, i) => new { Row = o, Index = i })
        .Where(r => (r.Row == null && updatedRow[r.Index] != null)
                || (r.Row != null && updatedRow[r.Index] != null
                && !r.Row.Equals(updatedRow[r.Index])))
            .SelectMany(r => new AppServices.NotificationData[]
            {
                new AppServices.NotificationData
                {
                    Key = string.Format("{0}OldValue",
                        columns[r.Index].ColumnName.EmailTemplateName(type)),
                    Value = Convert.ToString(currentRow[r.Index])
                },
                new AppServices.NotificationData
                {
                    Key = string.Format("{0}NewValue",
                        columns[r.Index].ColumnName.EmailTemplateName(type)),
                    Value = Convert.ToString(updatedRow[r.Index])
                }                        
            });

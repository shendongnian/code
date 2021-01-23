    public void Join (DataTable existing, DataTable newContent)
    {
        foreach (var row in newContent.Rows)
        {
           var newRow = existing.NewRow();
           // Copy data over
           existing.Rows.Add(newRow);
        }
    }

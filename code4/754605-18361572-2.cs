     public string[] GetHeaders(string feature){
        var row = dataGridView1.Rows
                               .OfType<DataGridViewRow>()
                               .FirstOrDefault(r=>r.Cells["feature"].Value.Equals(feature));
        if(row == null) return null;
        return row.Cells.OfType<DataGridViewCell>()
                        .Where(c=>c.Value.Equals("yes"))
                        .Select(c=>c.OwningColumn.HeaderText)
                        .ToArray();
     }

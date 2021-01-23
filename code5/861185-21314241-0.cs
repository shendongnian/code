    List<string> list = new List<string>();
    foreach (DataGridViewRow item in dataGridView1.Rows)
    {
        if (item.Cells.Count >= 2 && //atleast two columns
            item.Cells[1].Value != null) //value is not null
        {
            list.Add(item.Cells[1].Value.ToString());
        }
    }

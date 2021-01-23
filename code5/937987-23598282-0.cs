    for (int j = 0; j < dataGridView1.Columns.Count; j++)
    {
        table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText,fontTable));
    }
    //..
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        for (int k = 0; k < dataGridView1.Columns.Count; k++)
        {
             if (dataGridView1[k, i].Value != null)
             {
                  table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString(),fontTable));
             }
         }
    }

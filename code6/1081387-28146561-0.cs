    for (int x = 0; x < dataGridView.Rows.Count; x++)
    {
         if (dataGridView.Rows[x].Cells[1].Value.ToString() == dataTable.Rows[0][2].ToString())
         {
              same = true;
              counter = x;
         }
    }
    if (same == true)
    {
         dataGridView.Rows[counter].Cells[0].Value = int.Parse(dataGridView.Rows[counter].Cells[0].Value.ToString()) + 1;
         dataGridView.Rows[counter].Cells[2].Value = Convert.ToDecimal(dataTable.Rows[0][4].ToString()) * Convert.ToDecimal(dataGridView.Rows[counter].Cells[0].Value.ToString());
    }
    else
    {
        quantity = 1;
        dataGridView.Rows.Add(quantity, dataTable.Rows[0][2], dataTable.Rows[0][4]);
    }

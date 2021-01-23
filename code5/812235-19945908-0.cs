    (dataGridView1.Columns[0] as DataGridViewComboBoxColumn).DataSource = new List<string> { "Item1", "Item2", "Item3"};    
         for (int i = 0; i < list[0].Count; i++)
        {
            int number = dataGridView1.Rows.Add();
            dataGridView1.Rows[number].Cells[0].Value = list[3][i]; 
        }
    }

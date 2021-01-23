    (dataGridView1.Columns[0] as DataGridViewComboBoxColumn).DataSource 
     = new List<string> { "Apples", "Oranges", "Grapes"};    
         for (int i = 0; i < list[0].Count; i++)
        {
            int number = dataGridView1.Rows.Add();
            dataGridView1.Rows[number].Cells[0].Value = list[3][i]; //list[3][1]=="Apples"
        }
    }

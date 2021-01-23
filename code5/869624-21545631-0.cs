    dataGridView1.EnableHeadersVisualStyles = false;
    DataGridViewColumn dataGridViewColumn = dataGridView1.Columns["Column1"];
    dataGridViewColumn.HeaderCell.Style.BackColor = Color.Magenta;
    dataGridViewColumn.HeaderCell.Style.ForeColor = Color.Yellow;
    
    Color cl = dataGridViewColumn.HeaderCell.Style.BackColor;
    //or   
    Color cl2 = dataGridView1.Columns["Column1"].HeaderCell.Style.BackColor;

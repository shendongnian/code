    String Cell1=dataGridView1.Rows[0].Cells[0].Value.ToString();
    String Cell2=dataGridView1.Rows[0].Cells[1].Value.ToString();
    
    if(String.IsNullOrWhiteSpace(Cell1) && String.IsNullOrWhiteSpace(Cell2))
    {
    dataGridView1.Rows[0].Cells[2].ReadOnly = true;
    }

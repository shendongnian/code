    string name;
    if(dataGridView1.Rows[0].Cells[1].Value == null)
    {
       MessageBox.Show("Cell is empty");
    }
    else
    {
       name = dataGridView1.Rows[0].Cells[1].Value.ToString();
    }

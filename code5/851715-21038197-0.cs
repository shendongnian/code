    if(dataGridView1.SelectedCells.Count > 0)
    { 
       i = dataGridView1.SelectedCells[0] 
       OleDbConnection con = new OleDbConnection(constr);  
       OleDbCommand delcmd = new OleDbCommand();
       if (dataGridView1.Rows.Count > 1 && i != dataGridView1.Rows.Count - 1)
       {
           delcmd.CommandText = "DELETE FROM tb1 WHERE ID=" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "";
           con.Open();
           delcmd.Connection = con;
           delcmd.ExecuteNonQuery();
           con.Close();
           dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Index);
           MessageBox.Show("Row Deleted");
       }
    }
    else 
    {
      MessageBox.Show("Please select a row");
    }

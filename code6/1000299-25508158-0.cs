    textBox1.Text = "insert";
    cmd = new SqlCommand();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Connection = con;
    cmd.CommandText = "prcfunddetails";
    cmd.Parameters.Add("@action", SqlDbType.VarChar); //assign valid SqlDbType
    cmd.Parameters.Add("@fundid", SqlDbType.VarChar);
    //...
    for (int i = 0; i<dataGridView1.Rows.Count; i++)
    {    
        cmd.Parameters["@action"].Value =  textBox1.Text;
        cmd.Parameters["@fundid"].Value =  dataGridView1.Rows[i].Cells[0].Value;
        //...
        cmd.ExecuteNonQuery();
        MessageBox.Show("Records successfully inserted");
     }

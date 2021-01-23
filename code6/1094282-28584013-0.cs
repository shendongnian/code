    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\naresh\My stuff\Thal tre tsks trim\Thalassemia\Data\thalsemia.accdb");
    con.Open();
    
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    
    {
    
       OleDbCommand cmd= new OleDbCommand("INSERT INTO table1(name,number,salory,) VALUES
     ('"+dataGridView1.Rows[i].Cells["Column1"].Value+"','"+dataGridView1.Rows[i].Cells["Column2"].Value+"',
    '"+dataGridView1.Rows[i].Cells["Column3"].Value+" ' ",con);
    
       cmd.ExecuteNonQuery();
    
    }
    
    con.Close();

     //SQL connection
    SqlConnection con = new SqlConnection(@"Data Source=" + globalvariables.hosttxt 
    + "," + globalvariables.porttxt + "\\SQLEXPRESS;Database=ha;Persist Security
    Info=false; UID='" + globalvariables.user + "' ; PWD='" + globalvariables.psw + "'");
    SqlCommand command = con.CreateCommand();
    
    //SQL QUERY
    command.CommandText = "DELETE FROM bestillinger WHERE ordrenr = @ordre";
    command.Parameters.AddWithValue("@ordre",dataGridView1.
    SelectedRows[0].Cells["ordre"].Value.ToString())
    con.Open();
    var ordre = command.ExecuteScalar();
    con.Close();
    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);

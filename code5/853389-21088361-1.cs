    private void btnUpdate_Click(object sender, EventArgs e)
    {          
        OleDbConnection con = new OleDbConnection(constr);
        con.Open();
        OleDbCommand cmd = new OleDbCommand("Update tb1 set rollno=? WHERE name=?", con);
        cmd.Parameters.AddWithValue("name", txtproject_name.Text);
        cmd.Parameters.AddWithValue("rollno", textroll.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Updated sucessfully");           
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        var con = new OleDbConnection(constr);
        con.Open();
    
        var Sql_radio = string.Empty;
    
        if (radioButton1.Checked)
        {
            Sql_radio = "Insert Into tb1(name)Values ('Yes')";
        }
    
        if (radioButton2.Checked)
        {
            Sql_radio = "Insert Into tb1(name)Values ('no')";
        }
    
        var cmd = new OleDbCommand(Sql_radio, con);
    
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Inserted sucessfully");
    }

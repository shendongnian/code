        private void btnUpdate_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(constr);
        con.Open();
        string Sql_radio = String.Empty;
        if (radioButton1.Checked)
        {
             Sql_radio = "Insert Into tb1(name)Values ('Yes')";
        }
        if (radioButton2.Checked)
        {
            Sql_radio = "Insert Into tb1(name)Values ('no')";
        }
         OleDbCommand cmd = new OleDbCommand(Sql_radio, con);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Inserted sucessfully");
    }

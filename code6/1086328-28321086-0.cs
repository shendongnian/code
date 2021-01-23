    Public void log_in_btn_Click(object sender, EventArgs e)
    {
        try
        {
            con.open();
            String strQuery = "SELECT * FROM sign_up_table WHERE USERNAME = '" + txt_Username.Text + "' AND PASSWORD = '" + txt_Password.Text + "'";
            sqlcommand cmd = new sqlcommand(strQuery,con);
            sqlDataAdapter adpt = new sqlDataAdapter(cmd);
            Datatable dt = new Datatable();
            adpt.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                frm2.lbl_users_name.Text = dt.Rows[0]["NAME"].ToString();
                frm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect\nUsername or \nPassword!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.close();
        }
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

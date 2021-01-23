    private void btnOK_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con.Open();
            string s = "CREATE TABLE '"+rchtxtFieldCode.Text + "'(" +"'"+rchFieldTitle.Text +"'" + combDataType.Text + "" + ")";
            SqlCommand cmd = new SqlCommand(s, con);
            if (cmd.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("created");
            }
            con.Close();
        }

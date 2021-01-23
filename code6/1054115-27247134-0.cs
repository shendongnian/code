    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        string Degree = textBox5.Text;
        string degsql = "SELECT ModName FROM Module Where Degree = @Degree";
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SRSConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(degsql, con);
        cmd.Parameters.Add(new SqlParameter("Degree", Degree));
        DataSet dsm = new DataSet();
        SqlDataAdapter connect = new SqlDataAdapter(cmd);
        connect.Fill(dsm);
        this.listBox2.DataSource = dsm.Tables[0];
        this.listBox2.DisplayMember = "ModName";
    }

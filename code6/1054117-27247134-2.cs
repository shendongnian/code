    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        string Degree = textBox5.Text;
        string degsql = "SELECT ModName FROM Module Where Degree = @Degree";
    
        DataSet dsm = new DataSet();
    
        using(var con = new SqlConnection(Properties.Settings.Default.SRSConnectionString))
        {
            SqlCommand cmd = new SqlCommand(degsql, con);
            // use the appropriate SqlDbType:
            var parameter = new SqlParameter("@Degree", SqlDbType.Varchar)
            parameter.Value = Degree;
            cmd.Parameters.Add(parameter);
    
            SqlDataAdapter connect = new SqlDataAdapter(cmd);
            connect.Fill(dsm);
        }
    
        this.listBox2.DataSource = dsm.Tables[0];
        this.listBox2.DisplayMember = "ModName";

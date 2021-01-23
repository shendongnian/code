    protected void ButtonOk_Click(object sender, EventArgs e)
        {
           // OracleConnection connect = new OracleConnection();
           // connect.ConnectionString = ConfigurationManager.ConnectionStrings["Absensi2.Properties.Settings.Setting"].ConnectionString;
           //// SqlConnection connect = new SqlConnection(getConnection());
            var sql = "insert into master_dosen(NIP,NAMA_DOSEN,KETERANGAN) values (:NIP, :NAMA_DOSEN, :KETERANGAN)";
    
            using (OracleConnection c = new OracleConnection(ConfigurationManager.ConnectionStrings["Absensi2.Properties.Settings.Setting"].ConnectionString))
            {
                c.Open();
                using (OracleCommand cmd = new OracleCommand(sql, c))
                {
                    cmd.Parameters.Add(":NIP", TextBoxNIP.Text);
                    cmd.Parameters.Add(":NAMA_DOSEN", TextBoxNamaDosen.Text);
                    cmd.Parameters.Add(":KETERANGAN", TextBoxKeterangan.Text);
    
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                }
                c.Close();
            }

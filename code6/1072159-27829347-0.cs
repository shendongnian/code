    private void frmNewClient_Load(object sender, EventArgs e)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["Pigen"].ConnectionString;
        using(MySqlConnection cnn = new MySqlConnection(connectionString))
        using(MySqlCommand cmd = cnn.CreateCommand())
        {
            cnn.Open();
            cmd.CommandText = "sp_clearing_agent";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            using(MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
                combobox.DisplayMember = "clearing_agent_name";
                combobox.ValueMember = "clearing_agent_id";
                combobox.DataSource = dt;
                 
            }
        }
    }

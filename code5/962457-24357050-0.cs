    private void getTables(object sender, EventArgs e)
    {
    	dataGridView1.DataSource = dt;
    	string strConnect = "Data Source=|DataDirectory|\\LWADataBase.sdf";
    	using (SqlCeConnection con = new SqlCeConnection(strConnect)) {
    		con.Open();
    		using (SqlCeCommand com = new SqlCeCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", con)) {
    			using (SqlCeDataAdapter da = new SqlCeDataAdapter()) {
    				da.SelectCommand = com;
    				da.Fill(dt);
    			}
    		}
    	}
    }

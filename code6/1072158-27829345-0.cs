            DataTable dtTest = new DataTable();
            SqlConnection con=new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText="sp_clearing_agent";
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter sdaTest = new SqlDataAdapter(cmd);
            DataSet dsTest=new DataSet();
            sdaTest.Fill(dsTest);
            //binding data to combobox
            cmbTest.DataSource = dsTest.Tables[0];
            comboBox1.DataSource.DisplayMember="clearing_agent_id"
            comboBox1.DataSource.ValueMember="clearing_agent_name"
            comboBox1.DataBind();
            con.Close();

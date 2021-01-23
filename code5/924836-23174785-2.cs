    using (var cnx = new OracleConnection(connectionString)) 
        using (var ds = new DataSet())
            using (var da = new OracleDataAdapter(query)) {
                da.SelectCommand.CommandType = CommandType.Text;
                if (ConnectionState.Closed == cnx.State) cnx.Open();
                
                da.Fill(ds);
                
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "autorius";
                comboBox1.ValueMember = "aut_id";                                 
            }

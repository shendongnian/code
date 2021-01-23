       public void read()
       {
           try
           {
               OracleConnection conn = new OracleConnection("");
               OracleCommand cmd = new OracleCommand("select * from t1", conn);
               conn.Open();
               cmd.CommandType = CommandType.Text;
               DataSet ds = new DataSet();
               OracleDataAdapter da = new OracleDataAdapter();
               da.SelectCommand = cmd;
               da.Fill(ds);
               dataGridView1.DataSource = ds.Tables[0];
               
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }
    }

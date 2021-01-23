    OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=posv.accdb";
        conn.Open();
        string Expanse_Name = expanse_name.Text;
        string Expanse_Cost = expanse_cost.Text;
        string Expanse_Date = expanse_date.Value.ToString("m/d/Y");
        OleDbCommand cmd = new OleDbCommand("INSERT INTO expanses (Expanse_Name, Expanse_Cost,Expanse_Date) VALUES (@Expanse_Name, @Expanse_Cost,@Expanse_Date)", conn);
        if(conn.State == ConnectionState.Open){
            cmd.Parameters.Add("@Expanse_Name", OleDbType.VarChar, 20).Value = Expanse_Name;
            cmd.Parameters.Add("@Expanse_Cost", OleDbType.UnsignedInt, 20).Value = Expanse_Cost;
            cmd.Parameters.Add("@Expanse_Date", OleDbType.DBTimeStamp, 20).Value = Expanse_Date.;
            try {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Expanse Added Success fully!");
            }catch(OleDbException exps){
                MessageBox.Show(exps.Message);
                conn.Close();
            } // end try
        } //end conn state
    } 

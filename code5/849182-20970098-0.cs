    con.Open();
    OracleCommand cmd = new OracleCommand("Frm_Dealer_list_Prc_2_4", con);
    cmd.Parameters.Add("DlrID", OracleType.Cursor).Direction = ParameterDirection.Output;
    DataSet ds = new DataSet();
    OracleDataAdapter da = new OracleDataAdapter();
    da.SelectCommand = HaCommand;
    da.Fill(ds);
    comboBox1.DataSource = ds.Tables[0];

    DataTable dt = new DataTable();
    OleDbConnection oCon = new OleDbConnection();
    oCon.ConnectionString = _connStr;
    oCon.Open();
    OleDbDataAdapter da = new OleDbDataAdapter("SELECT AVG (courseRating) FROM Review_tbl", oCon);
    da.SelectCommand.CommandType = CommandType.Text;
    da.Fill(dt);
    oCon.Close();
    
    string value = dt.Rows[0].ItemArray[0].ToString();
    Textbox1.Text = value;

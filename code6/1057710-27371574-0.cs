    strSQL = "INSERT...";
    db.openconn("MOMT_Report", "Report");
    cmd = new SqlCommand(strSQL, db.cn);
    
    SqlParameter _Rptdate = new SqlParameter("@Rptdate", DbType.Int);
    cmd.Parameters.Add(_Rptdate);
    
    ...{repeat for remaining params}...
    for / while loop
    {
      _Rptdate.Value = Rptdate;
      // set other param values
      cmd.ExecuteNonQuery();
    }
    db.closeconn();

    [Test]
    public void RefCursorFromBatch()
    {
      OracleCommand cmd = new OracleCommand();
      cmd.CommandText = @"
      begin
        open :rcursor for
          SELECT
           trunc(to_date(:fromDate,'dd-mon-yyyy')) + NUMTODSINTERVAL(n,'day') AS Full_Date
          FROM (
          select (level-1) n
          from dual
          connect by level-1 <= trunc(to_date(:toDate,'dd-mon-yyyy')) - trunc(to_date(:fromDate,'dd-mon-yyyy'))
         )
        ;
      end;";
      cmd.BindByName = true;
      cmd.Parameters.Add("fromDate", OracleDbType.Date).Value = DateTime.Today.AddDays(-30);
      cmd.Parameters.Add("toDate", OracleDbType.Date).Value = DateTime.Today;
      cmd.Parameters.Add("rcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
      using (cmd.Connection = new OracleConnection("..."))
      {
        cmd.Connection.Open();
        var reader = cmd.ExecuteReader();
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Assert.Greater(dt.Rows.Count, 0);
      }
    }

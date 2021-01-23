      if (filenam.ToString() == ".xls")
      { constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathnam + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\""; }
      else if (filenam.ToString() == ".xlsx")
      { constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathnam + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\""; }
      else { Response.Write("<script>alert('Load Excel file Only')</script>"); }
      string Qry = "SELECT [Customer], [Project], [Contact], [Designation], [Phone], [EmailID],[Region] FROM [Sheet1$]";
      OleDbConnection conn = new OleDbConnection(constr);
      if (conn.State == ConnectionState.Closed)
      {
      conn.Open();
      OleDbCommand cmd = new OleDbCommand(Qry, conn);
      OleDbDataAdapter da = new OleDbDataAdapter();
      da.SelectCommand = cmd;
      DataTable dt = new DataTable();
      da.Fill(dt);
      if (dt != null && dt.Rows.Count > 0)
      {
      gv_upload.DataSource = dt;
      gv_upload.DataBind();
      }
      da.Dispose(); conn.Close(); conn.Dispose();
      }

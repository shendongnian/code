    private void GridBind(string StrQry="")
    {
      string Qry = string.Empty;
      //StrQry = "Select * from tbl_Emp where Dept='Acc'";
      if (StrQry != string.Empty)
      {
        Qry = StrQry;
      }
      else 
      {
        Qry = "Select * from tbl_Emp";
      }
      Conn();
      Cmd = new SqlCommand(Qry,con);
      da = new SqldataAdapter(cmd);
      da.fil(dt);
      if (dt != null && dt.Rows.Count > 0)
      {
        gridviewobj.datasource = dt;
        gridviewobj.DataBind();
      }
    }

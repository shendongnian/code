    public DataSet leavestatus(string code, DateTime date1, DateTime date2, 
                             int month, int year, int dept, string value)
    {
      string data = "";
      DataSet dstData = new DataSet("Data");
      SQLDataAdapter adpData;
      adpData = new SQLDataAdapter("Leavetypedetails Report", conn);
      adpData.SelectCommand.Parameters.Add("@code", SqlDbType.NVarChar).value = code;
      adpData.SelectCommand.CommandType = CommandType.StoredProcedure;
      adpData.Fill(dstData); 
      return dstData;
     }
    
     protected void view_Click(object sender, Event Args e)
      {
            Grid.Datasource = leavestatus(.....);
            Grid.DataBind();
      }

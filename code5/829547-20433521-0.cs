    public IEnumerable<DataTable> getFiles(List<string> userIDs)
    {
        var result = new List<DataTable>();
        string spUpdate = "usp_Update";
        string spSelect = "usp_Select";
        try
        {
            foreach (string item in userIDs)
            {
                
                DataSet ds = OracleConnectionHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, spSelect.ToUpper(), userIDs);
                OracleConnectionHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, spUpdate.ToUpper(), userIDs);
                result.Add(ds.Tables[0]);
            }
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

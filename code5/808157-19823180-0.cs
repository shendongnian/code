    SqlConnection dbConn = null;
    LabelData LadelList = new LabelData();
    try
    {
        using (dbConn = new SqlConnection(Properties.Settings.Default["connectionname"].ToString()))
        {
    
            SqlCommand addNewVersion = new SqlCommand(@"INSERT INTO PackLabelVersion (VersionID,VersionNumber,FormatID) VALUES (@VersionID,@VersionNumber,@FormatID)", dbConn);
            addNewVersion.Parameters.AddWithValue("@VersionID", VersionID);
            addNewVersion.Parameters.AddWithValue("@VersionNumber", VersionNumber);
            addNewVersion.Parameters.AddWithValue("@Quantity", FormatID);
            dbConn.Open();
            addNewVersion.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
        throw ex;
    }

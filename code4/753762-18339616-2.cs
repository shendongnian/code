    [WebMethod]
    public void InsertDrugNameAndColorToDatabase(ServiceData theData)
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            using (var cmd = new SqlCommand("spInsertDrugText", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@drugName", theData.DrugName);
                cmd.Parameters.AddWithValue("@drugColor", theData.DrugColor);
                cmd.ExecuteNonQuery();
            }
        }
    }

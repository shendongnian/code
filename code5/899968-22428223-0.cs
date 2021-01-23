    static public bool HasDuplicate(string ProductID, string connString)
    {
        bool hasDup = true;
        Int32 numRecords = 0;
        string sql =
            "Select count(*) From tblindividualproduct where ProductID = @ProductIdText";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ProductIdText", SqlDbType.VarChar);
            cmd.Parameters["@ProductIdText"].Value = ProductID;
            try
            {
                conn.Open();
                numRecords = (Int32)cmd.ExecuteScalar();
                if(numRecords == 0) hasDup = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return hasDup;
    }

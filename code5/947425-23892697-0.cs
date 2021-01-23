    public string GetLeftPanelData()
    {
        try
        {
            SqlCommand comGetLeftPanelData = new SqlCommand("SP_GetLeftPanelData", con);
            comGetLeftPanelData.CommandType = CommandType.StoredProcedure;
            con.Open();
            string returnData = (string)comGetLeftPanelData.ExecuteScalar();
            con.Close();
            return returnData;
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

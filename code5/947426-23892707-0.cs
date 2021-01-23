    public string GetLeftPanelData()
    {
        try
        {
            SqlCommand comGetLeftPanelData = new SqlCommand("SP_GetLeftPanelData", con);
            comGetLeftPanelData.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comGetLeftPanelData);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["Description"].ToString();
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

     void LoadGrid(string srtexpr = "", string direc = "")
    {
        sqlcmd = new SqlCommand("selectActiveLogs", sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        try
        {
            sqlcon.Open();
            da = new SqlDataAdapter(sqlcmd);
            dt.Clear();
            da.Fill(dt);
    
            if (srtexpr != "" && direc != "")
            {
                dt.DefaultView.Sort = srtexpr + " " + direc;
            } gvLogNotice.DataSource = dt;
            gvLogNotice.DataBind();
    
    
        }
        catch (Exception ex)
        {
    
        }
        finally
        {
            sqlcon.Close();
        }
    }

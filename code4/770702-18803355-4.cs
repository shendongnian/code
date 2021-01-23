     void LoadGrid(string srtexpr, string direc)
    {
        sqlcmd = new SqlCommand("selectActiveLogs", sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        try
        {
            sqlcon.Open();
            da = new SqlDataAdapter(sqlcmd);
            dt.Clear();
            da.Fill(dt);
    
            DataView dv = new DataView (dt);
            dv.Sort = srtexpr + " " + direc;
            gvLogNotice.DataSource = dv;
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

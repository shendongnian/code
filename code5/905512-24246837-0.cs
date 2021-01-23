    publicActionResultGenerateReport()
    {
        SqlConnection con = newSqlConnection(“data source=SILSOFTU2;initial catalog=BLC_DEV;persist security info=True;user id=sa;password=234;”);
        DataTabledt = newDataTable();
        try
        {
            con.Open();
            SqlCommandcmd = newSqlCommand(“SELECT * FROM Sys_Grade”, con);
            SqlDataAdapteradp = newSqlDataAdapter(cmd);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
        }
    }

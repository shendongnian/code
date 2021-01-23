    if(DateTime.TryParse(txtStartingdate.Text, out stdate)
    {
        SqlParameter projectStartingDateParam = new SqlParameter("@projectstartingdate", SqlDbType.DateTime);
            projectStartingDateParam.Value = stdate;
        cmd.Parameters.Add(projectStartingDateParam);
    }

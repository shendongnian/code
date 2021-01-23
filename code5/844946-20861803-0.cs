    string ID = ddlPractice.SelectedValue;
    string TYPE = DDL_TYPE.SelectedValue;
    SqlConnection con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
    SqlDataAdapter da = new SqlDataAdapter(
        @"select SET_SK, UNIT_NM, TYPE, INIT_PHASE FROM myTable WHERE UNIT_NM =@ID AND TYPE = @TYPE",
        con);
    SqlCommandBuilder builder = new SqlCommandBuilder(da);
    da.UpdateCommand = builder.GetUpdateCommand();
    DataTable dtSETS = new DataTable();
    da.SelectCommand.Parameters.AddWithValue("@ID", (ID));
    da.SelectCommand.Parameters.AddWithValue("@TYPE", (TYPE));
    da.Fill(dtSETS);
    if (dtSETS.Rows.Count > 0)
    {
        DataRow dtSETS_row = dtSETS.Rows[0];
        long SET_SK = dtSETS_row.Field<long>("SET_SK");
        if (dtSETS_row.Field<string>("INIT_PHASE") == null)
        {
            dtSETS_row["INIT_PHASE"] = 1;
        }
    }
    da.Update(dtSETS);

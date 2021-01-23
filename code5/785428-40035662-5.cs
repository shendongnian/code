    SqlParameter[] parameters =
    {
        new SqlParameter("@Task", "insert"),
        new SqlParameter("@Name", clsPluginHelper.DbNullIfNullOrEmpty(txtinstalName.Text)),
        new SqlParameter("@Descp", clsPluginHelper.DbNullIfNullOrEmpty(txtInstDescp.Text)),
        clsPluginHelper.Parameter(SqlDbType.DateTime, "@StartDate",dtpInstStartDate.Text),
        clsPluginHelper.Parameter(SqlDbType.DateTime, "@EndDate",dtpInstalEndDate.Text)
    };

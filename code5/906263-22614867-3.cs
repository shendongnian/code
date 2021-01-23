    try
        {
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@RowMeterialID ", num);
            sqlComm.CommandTimeout = 600;
            DataSet dsMyResult = new DataSet();
            sqlComm.ExecuteReader();
            ddl.DataSource = dsMyResult;
            ddl.DataBind();
            ddl.DataTextField = "sName";
            ddl.DataValueField = "sName";
        }

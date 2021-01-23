    AdomdClient.AdomdRestrictionCollection restrColl = new AdomdClient.AdomdRestrictionCollection();
    restrColl.Add("CUBE_NAME", cube.Name);
    DataSet ds = clientConn.GetSchemaDataSet("MDSCHEMA_MEASURES", restrColl);
    foreach(DataRow row in ds.Tables[0].Rows) {
        string expr = row.Field<string>("EXPRESSION");
        if (string.IsNullOrEmpty(expr)) {
            // measure is a physical measure
        } else {
            // measure is a calculated measure, and 'expr' is its definition
        }
        // use other columns like MEASURE_NAME, MEASURE_UNIQUE_NAME, DATA_TYPE,
        // DEFAULT_FORMAT_STRING ... as you need them
    }

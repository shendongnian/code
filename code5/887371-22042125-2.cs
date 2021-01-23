    protected void Page_Load(object sender, EventArgs e)
    {
        //Fetching of data from SP here and putting the resultset in dt1
        //dt1 is of type datatable
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            if (dt1.Rows[i]["Size"].ToString() == "N/A")
                continue;
            for (int j = 0; j < dt1.Columns.Count; j++)
            {
                object colVal = dt1.Rows[i][j];
                if (colVal == DBNull.Value || Convert.ToDecimal(colVal) == 0)
                {
                    decimal calVal = (Convert.ToDecimal(dt1.Rows[i + 1][j]) / Convert.ToDecimal(dt1.Rows[i + 1]["R"])) * Convert.ToDecimal(dt1.Rows[i]["R"]);
                    dt1.Rows[i][j] = calVal;
                }
            }
        }
        //GridView binding code here
    }

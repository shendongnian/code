    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        // define relevant date
        string strDate = string.Empty;
        if (txtdatesearch.Text.Length != 0) { // one "if condition" to determine which date to use
            DateTime DTentered1 = DateTime.ParseExact(txtdatesearch.Text, CalendarExtender1.Format, null);
            strDate = DTentered1.ToString("dd-MM-yy");
        } else {
            strDate = System.DateTime.Today.ToString("dd-MM-yy");
        }
        // define query
        string query = "SELECT tblhomework.ID, tblteacher.TEACHERNAME, tblclass.CLASSNAME, tblhomework.Title, tblhomework.HomeworkDetail, tblhomework.StudentsCode FROM tblhomework JOIN tblclass ON tblclass.CLASSCODE = tblhomework.ClassCode JOIN tblteacher ON tblteacher.TSHORTNAME = tblhomework.Tshortcode WHERE (tblhomework.ClassCode = @dropClass OR @dropClass IS NULL) AND (tblhomework.TshortCode = @teacherName OR @teacherName IS NULL) AND (tblhomework.StudentsCode LIKE @studentCode) AND (DATE_FORMAT(tblhomework.DateCreated,'%d-%m-%y') = @dateEntered)";
        // define connection string
        OdbcConnection conn = new OdbcConnection(YourConnectionStringGoesHere);
        OdbcCommand cmd = null;
        // define command
        using (OdbcCommand cmd = new OdbcCommand(query, conn)) {
            // add parameters using the ternary operator (?:) to handle cases that are not the date.
            // The ternary operator works like an inline "if (condition) {this} else {that}"
            // It's written in the form of "condition ? this : that;"
            cmd.Parameters.Add("dropClass", OdbcType.Int).Value = (drpclass.SelectedIndex != 0 ? drpclass.SelectedItem.Value : System.DBNull.Value);
            cmd.Parameters.Add("teacherName", OdbcType.VarChar, 50).Value = (txt_tchrname.Text.Length != 0 ? txt_tchrname.Text.ToString() : System.DBNull.Value);
            cmd.Parameters.Add("studentCode", OdbcType.VarChar, 50).Value = (txt_studentcode.Text.Length != 0 ? "%" + txt_studentcode.Text.ToString() + "%" : "%");
            cmd.Parameters.Add("dateEntered", OdbcType.VarChar, 50).Value = strDate;
            conn.Open();
            // you're using a dataset, and the OdbcCommand returns a reader
            // see the function defined below for ConvertDataReaderToDataSet
            DataSet(ds == ConvertDataReaderToDataSet(cmd.ExecuteReader()));
            // I'm not familiar with the openDataset(String, String) function, and I'm not sure what "obj" is...
            // Is this supposed to cache the result in session?
            // ds = obj.openDataset(sqlsearch, Session["SCHOOLCODE"].ToString());
        }
        if ((ds.Tables(0).Rows.Count == 0)) {
            //lbl_norecord.Text = "Record Not Found";
            //lbl_norecord.Visible = True
            grdhomework.Visible = false;
            classnorecord.Visible = true;
            classnorecordtoday.Visible = false;
            classalert.Visible = false;
            Response.Write("");
        } else {
            grdhomework.Visible = true;
            grdhomework.DataSource = ds;
            grdhomework.DataBind();
            blankdata();
            classnorecord.Visible = false;
            classnorecordtoday.Visible = false;
            classalert.Visible = false;
        }
    }
    // function ConvertDataReaderToDataSet by Mohammed Fauzi, found at http://mohammedfauzi.blogspot.com/2009/12/convert-datareader-to-dataset-through-c.html
    public DataSet ConvertDataReaderToDataSet(System.Data.Odbc.OdbcDataReader reader)
    {
        DataSet dataSet = new DataSet();
        do {
            // Create data table in runtime
            DataTable schemaTable = reader.GetSchemaTable();
            DataTable dataTable = new DataTable();
            if (schemaTable != null) {
                for (int i = 0; i < schemaTable.Rows.Count; i++) {
                    DataRow dataRow = schemaTable.Rows[i];
                    // Create a column name as provided in Schema
                    string columnName = (string)dataRow["ColumnName"];
                    // Define Column Type here
                    DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                    //Adding Column to table
                    dataTable.Columns.Add(column);
                }
                dataSet.Tables.Add(dataTable);
                // Fill the data table from reader data
                while (reader.Read()) {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++) {
                        dataRow[i] = reader.GetValue(i);
                    }
                    dataTable.Rows.Add(dataRow);
                }
            } else {
                // No records were returned
                DataColumn column = new DataColumn("RowsAffected");
                dataTable.Columns.Add(column);
                dataSet.Tables.Add(dataTable);
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = reader.RecordsAffected;
                dataTable.Rows.Add(dataRow);
            }
        } while (reader.NextResult());
        return dataSet;
    }

    private void exportToCSV()
    {
        //Asks the filenam with a SaveFileDialog control.
        SaveFileDialog saveFileDialogCSV = new SaveFileDialog();
        saveFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
        saveFileDialogCSV.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        saveFileDialogCSV.FilterIndex = 1;
        saveFileDialogCSV.RestoreDirectory = true;
        if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
        {
            // Runs the export operation if the given filenam is valid.
            exportToCSVfile(saveFileDialogCSV.FileName.ToString());
        }
    }
     * Exports data to the CSV file.
     */
    private void exportToCSVfile(string fileOut)
    {
        // Connects to the database, and makes the select command.
        string sqlQuery = "select * from dbo." + this.lbxTables.SelectedItem.ToString();
        SqlCommand command = new SqlCommand(sqlQuery, objConnDB_Auto);
        // Creates a SqlDataReader instance to read data from the table.
        SqlDataReader dr = command.ExecuteReader();
        // Retrives the schema of the table.
        DataTable dtSchema = dr.GetSchemaTable();
        // Creates the CSV file as a stream, using the given encoding.
        StreamWriter sw = new StreamWriter(fileOut, false, this.encodingCSV);
        string strRow; // represents a full row
        // Writes the column headers if the user previously asked that.
        if (this.chkFirstRowColumnNames.Checked)
        {
            sw.WriteLine(columnNames(dtSchema, this.separator));
        }
        // Reads the rows one by one from the SqlDataReader
        // transfers them to a string with the given separator character and
        // writes it to the file.
        while (dr.Read())
        {
            strRow = "";
            for (int i = 0; i < dr.FieldCount; i++)
            {
                switch (Convert.ToString(dr.GetFieldType(i)))
                {
                    case "System.Int16":
                        strRow += Convert.ToString(dr.GetInt16(i));
                        break;
                    case "System.Int32" :
                        strRow += Convert.ToString(dr.GetInt32(i));
                        break;
                    case "System.Int64":
                        strRow += Convert.ToString(dr.GetInt64(i));
                        break;
                    case "System.Decimal":
                        strRow += Convert.ToString(dr.GetDecimal(i));
                        break;
                    case "System.Double":
                        strRow += Convert.ToString(dr.GetDouble(i));
                        break;
                    case "System.Float":
                        strRow += Convert.ToString(dr.GetFloat(i));
                        break;
                    case "System.Guid":
                        strRow += Convert.ToString(dr.GetGuid(i));
                        break;
                    case "System.String":
                        strRow += dr.GetString(i);
                        break;
                    case "System.Boolean":
                        strRow += Convert.ToString(dr.GetBoolean(i));
                        break;
                    case "System.DateTime":
                        strRow += Convert.ToString(dr.GetDateTime(i));
                        break;
                }
                if (i < dr.FieldCount - 1)
                {
                    strRow += this.separator;
                }
            }
            sw.WriteLine(strRow);
        }
        // Closes the text stream and the database connenction.
        sw.Close();
        dr.Close();
        // Notifies the user.
        MessageBox.Show("ready");
    }

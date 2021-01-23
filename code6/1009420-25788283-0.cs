                            //Create New Dataset
                        DataSet myDataSet = new DataSet();
                        DataTable myDataTable = myDataSet.Tables.Add("Temp");
                        myDataTable.Columns.Add("ID");
                        myDataTable.Columns.Add("JobNumber");
                        myDataTable.Columns.Add("DirectoryName");
                        myDataTable.Columns.Add("DrawingName");
                        myDataTable.Columns.Add("DateAdded");
                        myDataTable.Columns.Add("LastAccessedDate");
                        myDataTable.Columns.Add("LastAccessedUserName");
                        myDataTable.Columns.Add("ClientName");
                        myDataTable.Columns.Add("ContentType");
                        myDataTable.Columns.Add("Description");
                        
                        //Read From Database
                        nexusDBDataSet.Drawing_Table.Clear();
                        drawing_TableTableAdapter.FillByJobNumber(nexusDBDataSet.Drawing_Table, OldJobcardNumber);
                        foreach (DataRow myRow in nexusDBDataSet.Drawing_Table.Rows)
                        {
                            //Read from database
                            string DirectoryName = myRow["DirectoryName"].ToString();
                            string DrawingName = myRow["DrawingName"].ToString();
                            string DateAdded = myRow["DateAdded"].ToString();
                            string LastAccessedDate = myRow["LastAccessedDate"].ToString();
                            string LastAccessedUserName = myRow["LastAccessedUserName"].ToString();
                            string ClientName = myRow["ClientName"].ToString();
                            string ContentType = myRow["ContentType"].ToString();
                            string Description = myRow["Description"].ToString();
                            //write to temp data table
                            DataRow DrawingDataRow = myDataTable.NewRow();
                            DrawingDataRow["JobNumber"] = NewJobcardNumber;
                            DrawingDataRow["DirectoryName"] = DirectoryName.Replace("\\" + OldJobcardNumber + "\\", "\\" + NewJobcardNumber + "\\");
                            DrawingDataRow["DrawingName"] = DrawingName;
                            DrawingDataRow["DateAdded"] = DateAdded;
                            DrawingDataRow["LastAccessedDate"] = LastAccessedDate;
                            DrawingDataRow["LastAccessedUserName"] = LastAccessedUserName;
                            DrawingDataRow["ClientName"] = ClientName;
                            DrawingDataRow["ContentType"] = ContentType;
                            DrawingDataRow["Description"] = Description;
                            myDataTable.Rows.Add(DrawingDataRow);
                        }
                        //Refresh DataBase
                        nexusDBDataSet.Drawing_Table.Clear();
                        drawing_TableTableAdapter.Fill(nexusDBDataSet.Drawing_Table);
                        foreach (DataRow myRow in myDataTable.Rows)
                        {
                            //read from temp data table
                            string JobNumber = myRow["JobNumber"].ToString();
                            string DirectoryName = myRow["DirectoryName"].ToString();
                            string DrawingName = myRow["DrawingName"].ToString();
                            string DateAdded = myRow["DateAdded"].ToString();
                            string LastAccessedDate = myRow["LastAccessedDate"].ToString();
                            string LastAccessedUserName = myRow["LastAccessedUserName"].ToString();
                            string ClientName = myRow["ClientName"].ToString();
                            string ContentType = myRow["ContentType"].ToString();
                            string Description = myRow["Description"].ToString();
                            //Write back to DataBase
                            DataRow DrawingDataRow = nexusDBDataSet.Drawing_Table.NewRow();
                            DrawingDataRow["JobNumber"] = JobNumber;
                            DrawingDataRow["DirectoryName"] = DirectoryName;
                            DrawingDataRow["DrawingName"] = DrawingName;
                            DrawingDataRow["DateAdded"] = DateAdded;
                            DrawingDataRow["LastAccessedDate"] = LastAccessedDate;
                            DrawingDataRow["LastAccessedUserName"] = LastAccessedUserName;
                            DrawingDataRow["ClientName"] = ClientName;
                            DrawingDataRow["ContentType"] = ContentType;
                            DrawingDataRow["Description"] = Description;
                            nexusDBDataSet.Drawing_Table.Rows.Add(DrawingDataRow);
                        }
                        myDataSet.Dispose();
                        //Updating
                        this.Validate();
                        drawing_TableBindingSource.EndEdit();
                        tableAdapterManager.UpdateAll(nexusDBDataSet);
                        RefreshData();

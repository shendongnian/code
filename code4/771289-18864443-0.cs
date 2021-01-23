    DataTable boundTable = Utils.ConvertToDataTable(MyList);
    /// <summary>
            /// Convert list to datatable
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public static DataTable ConvertToDataTable(IList<MyEntity> data)
            {
                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(BDWData));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (BDWData item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;
    
            }
    CreateXLSFile(boundTable, FileName);
    /// Create and Save Excel File from Datatable
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="strFileName"></param>
            public void CreateXLSFile(DataTable dt, string strFileName)
            {
    
                #region Export List to XLS
    
                string date = DateTime.Now.ToString("MMddyyyyHHmmssfff");
                string path = strFileName + "_" + date + ".xls";
                if (dt.Rows.Count > 0)
                {
                    // Create a file to write to.
                    Directory.SetCurrentDirectory(ArchiveReportRoot);// Changed the default location of the storage of the file.
                    StreamWriter sw = File.AppendText(path); //Append the file name with the file path.
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<TABLE Border=1 ID=\"TableH2\">");
                    sb.AppendLine("<TR>");
                    sb.Append("<TD colspan=\"" + dt.Columns.Count + "\" style=\"background-color:#88b2fe\" align=\"center\">"
                                                                + "<b> " + strFileName
                                                                + "</b>" + "</TD>");
                    sb.AppendLine("</TR>");
                    sb.AppendLine("<TR>");
                    for (int count = 0; count < dt.Columns.Count; count++)
                    {
                        sb.AppendLine("<TD style=\"background-color:#88b2fe\"><b>" +
                            dt.Columns[count].ColumnName + "</b></TD>");
                    }
                    sb.AppendLine("</TR>");
                    for (int count = 0; count < dt.Rows.Count; count++)
                    {
                        sb.AppendLine("<TR>");
                        DataRow dr = dt.Rows[count];
                        for (int cellCount = 0; cellCount < dt.Columns.Count; cellCount++)
                        {
                            sb.AppendLine("<TD style=\"mso-number-format:'\\@';\">" + dr[cellCount] + "</TD>");
                        }
                        sb.AppendLine("</TR>");
                    }
                    sb.AppendLine("<TR>");
                    for (int count = 0; count < dt.Columns.Count; count++)
                    {
                        sb.AppendLine("<TD style=\"background-color:#88b2fe\"><b>" + "</b></TD>");
                    }
    
                    sb.AppendLine("</TR>");
                    sb.AppendLine("</TABLE>");
                    sw.Write(sb.ToString());
                    sw.Write("\n");
                    sw.Close();
                }
    
                else
                {
                    #region Logging to the console and text file
    
                    //***** Logging - START *****
                    sb.Length = 0;
                    sb.Append(Utils.CurrentDateTime);
                    sb.Append("No BDW Records found on  " + Utils.CurrentDate);
                    if (Utils.IsLoggingEnabled)
                    {
                        Utils.LogException(sb.ToString(), LogListener.FireBackendListener);
                    }
                    Utils.WriteToConsole(sb.ToString());
    
                    //***** Logging - END *****
                    #endregion Logging to the console and text file
                }
    
                #endregion
    
            }

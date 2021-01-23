                        DataTable dtCloned = ds.Tables[0].Clone();
                        foreach (DataColumn c in ds.Tables[0].Columns)
                        {
                            if (c.DataType == typeof(DateTime))
                            {
                                dtCloned.Columns[c.ColumnName].DataType = typeof(string);
                                colNames.Add(c.ColumnName);
                            }
                        }
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
    
                        foreach (DataRow dr in dtCloned.Rows)
                        {
                            foreach (DataColumn dc in dtCloned.Columns)
                            {
                                if (colNames.Contains(dc.ColumnName))
                                {
                                    string dt = Convert.ToString(dr[dc]);
                                    if (!String.IsNullOrEmpty(dt))
                                    {
                                        DateTime date = DateTime.ParseExact(dt.Substring(0, dt.IndexOf(' ')), "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        dr[dc] = date.ToString("MM/dd/yyyy");
                                    }
                                }
                            }
                        }

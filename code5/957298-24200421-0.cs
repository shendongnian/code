     DataTable dt_reorder = ds1.Tables[i];
    
                    //string[] columnNames = (from dc in dt_reorder.Columns.Cast<DataColumn>() select dc.ColumnName).OrderByDescending(c => c.Colum);
    
                    System.Collections.Generic.List<string> lstColNames = (from DataColumn col in dt_reorder.Columns select col.ColumnName).ToList();
    
    
    
                    foreach (string value in lstColNames)
                    {
                        string aa = value.ToString();
                        if (!aa.Contains("-past"))
                        {
                            if (lstColNames.Contains(aa + "-past"))
                            {
                                dt_reorder.Columns[aa + "-Previous"].SetOrdinal(dt_reorder.Columns.IndexOf(aa) + 1);
                            }
                        
                        }
                        
                    }

     else if (dsVX130.Tables["tAttributes"].Rows.Count > 0)
                        {
                            var rowsOnlyIntblsAttributes = from r in tblsAttributes.AsEnumerable() //was dt1
                            //make sure there aren't any matching names in dt2
                            where !tbltAttributes.AsEnumerable().Any(r2 => r["VistaFieldNumber"].ToString().Trim().ToLower() == r2["FMFieldNumber"].ToString().Trim().ToLower())
                            select r;
    
                            if (rowsOnlyIntblsAttributes.Any())
                            { 
                                DataTable result = rowsOnlyIntblsAttributes.CopyToDataTable();
    
                            //result.Rows[0]["VistaFieldNumber"]
                            string vresult;
                            for (int i = 0; i < result.Rows.Count; i++)
                              
                            //foreach (DataRow dr in result.Rows)
                            {
                                //var tempRow = result.Rows[i];
                                //var temp = result.Rows[i][0];
                                vresult=result.Rows[i]["VistaFieldNumber"].ToString();
                             for (int j = 0; j < tblsAttributes.Rows.Count; j++)
                                //foreach (DataRow dr1 in tblsAttributes.Rows)
                                {
                                    DataRow dr1 = tblsAttributes.Rows[j];
                                    if (dr1["VistaFieldNumber"].ToString() == vresult)
                                  {
                                    dr1.Delete();
                                    tblsAttributes.AcceptChanges();
                                    break;
                                  }
                                    //tblsAttributes.AcceptChanges();
                                }
                            }
                        }
                            //tblsAttributes.AcceptChanges();
                            applyAttributes();

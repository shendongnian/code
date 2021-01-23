             if (cmbXsd.SelectedIndex == 0)
    
                {
                    cmbDt.Items.Clear();
                    XmlDataDocument xmldd = new XmlDataDocument();
                    DataSet ds = xmldd.DataSet;
                    for (int j = 0; j <= dtfill.Rows.Count - 1; j++)
                    {
                        string filename = dtfill.Rows[j][0].ToString();
                        string dirpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
                        ds.ReadXmlSchema(dirpath);
                        DataTableCollection dtc = ds.Tables;
                        for (int i = 0; i < dtc.Count; i++)
                        {
                            DataTable dt = ds.Tables[i];
                            GetTableNames(ds);
                            break;
                         }
                        break;
                    }
                }

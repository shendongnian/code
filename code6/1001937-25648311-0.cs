    // check whether the dataset is manual; if so add the subreport queries
            if (AARpt.HasSubreports)
            {
                string srName;
                string sProc;
                using (AAData dc = new AAData(AAApp, true))
                {
                    for (int i = 0; i < cRpt.ReportDefinition.ReportObjects.Count; i++)
                    {
                        ReportObject CurrentObject = cRpt.ReportDefinition.ReportObjects[i];
                        if (CurrentObject.Kind == CrystalDecisions.Shared.ReportObjectKind.SubreportObject)
                        {
                            SubreportObject sr = (SubreportObject)CurrentObject;
                            rd = sr.OpenSubreport(sr.SubreportName );
                            srName = sr.SubreportName;
                            
                            if (AARpt.SubReps.TryGetValue(srName, out sProc))
                            {
                                dsSubRept = dc.LoadSet(sProc);
                                if (dsSubRept != null)
                                {
                                    // Following line added (not sure if needed, but was suggested in several spots)
                                    rd.DataSourceConnections.Clear();
                                    // The datasource in the following line changed - this was my real issue
                                    DataTable dt1 = dsSubRept.Tables["MyTable"];
                                    rd.SetDataSource(dt1);
                                    rd.VerifyDatabase();
                                    
                                }
                                else
                                {
                                    MessageBox.Show("We're sorry, but an error was encountered attempting to create this report","Utility", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }
                            }
                        }
                     }
                }
            }
        // The following is part of a class for loading data, but it is straightforward otherwise
        // I just included so you know that it returns a DataSet with a table named "MyTable"
        public DataSet LoadSet(SqlCommand _cmd)
        {
            // returns table "MyTable"
            SqlDataAdapter DA;
            DataSet DS = new DataSet();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Connection = _Conn;
            DA = new SqlDataAdapter(_cmd);
            DA.Fill(DS, "MyTable");
            return DS;
        }

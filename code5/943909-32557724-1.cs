     public static byte[] GeneratePBAReport()
            {
                
    
                string l_spName = string.Empty;
                string l_reportPath = string.Empty;
                var repCol = new List<ReportDataSource>();
    
                var repParCol = new ReportParameter[1];
                if (id == "")
                {
                   
                    l_reportPath = HttpContext.Current.Server.MapPath("~\\.rdlc");
                    l_spName = "";
                }
                else
                {
                    l_reportPath = HttpContext.Current.Server.MapPath("~\\.rdlc");
                    l_spName = "";
                }
    
                repParCol[0] = new ReportParameter("pID", "");
                
                var ds = new DataSet();
                using (var sqlCmd = new SqlCommand(l_spName, new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString)))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    var sqlParam = new SqlParameter() { Value = "", ParameterName = "" };
                    sqlCmd.Parameters.Add(sqlParam);
                    sqlCmd.CommandTimeout = 300;
                    using (var sqlAdapter = new SqlDataAdapter(sqlCmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }
    
                var rds = new ReportDataSource();
                rds.Name = "";
                rds.Value = ds.Tables[0];
                //l_report.DataSources.Add(rds);
                repCol.Add(rds);
    
                rds = new ReportDataSource();
                rds.Name = "";
                rds.Value = ds.Tables[1];
                //l_report.DataSources.Add(rds);
                repCol.Add(rds);
    
                rds = new ReportDataSource();
                rds.Name = "";
                rds.Value = ds.Tables[2];
                //l_report.DataSources.Add(rds);
                repCol.Add(rds);
    
                rds = new ReportDataSource();
                rds.Name = "";
                rds.Value = ds.Tables[3];
                //l_report.DataSources.Add(rds);
                repCol.Add(rds);
    
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                string deviceInfo;
              
    
                deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                
                return NewDomainReport.Render("PDF", deviceInfo, "-" , l_reportPath, true, repCol, string.Empty, new List<string[]>(), repParCol);
            }

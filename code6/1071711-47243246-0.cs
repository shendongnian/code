     ReportDocument cryRpt = new ReportDocument();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                string path = "" + Application.StartupPath + "\\Mgc\\Invoice.rpt";
                cryRpt.Load(path);
                cryRpt.SetParameterValue("billno", Program.billno);
                crConnectionInfo.UserID = "userid";
                crConnectionInfo.Password = "Password";
                crConnectionInfo.ServerName = "servernme";
                crConnectionInfo.DatabaseName = "database;
                CrTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }
              
                    crystalReportViewer1.ReportSource = cryRpt;
                    crystalReportViewer1.Refresh();
                

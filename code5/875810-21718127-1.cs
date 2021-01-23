    private void PrintReport()
        {
            ReportDocument report = new ReportDocument();
            report.Load("ReportPath");
            
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "HPL-WTS";
            crConnectionInfo.DatabaseName = "Enterprise32";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "*********";
            TableLogOnInfo crTableLogoninfo = new TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in report.Database.Tables)
            {
                crTableLogoninfo = CrTable.LogOnInfo;
                crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crTableLogoninfo);
            }
            foreach (ReportDocument subreport in report.Subreports)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                {
                    crTableLogoninfo = CrTable.LogOnInfo;
                    crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crTableLogoninfo);
                }
            }                         
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
        }

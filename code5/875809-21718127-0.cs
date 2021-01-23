    ConnectionInfo crConnectionInfo = new ConnectionInfo();
    crConnectionInfo.ServerName = "servername"
    crConnectionInfo.DatabaseName = "databasename";
    crConnectionInfo.UserID = "userid";
    crConnectionInfo.Password = "password";
    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in report.Database.Tables)
    {
    	crtableLogoninfo = CrTable.LogOnInfo;
    	crtableLogoninfo.ConnectionInfo = crConnectionInfo;
    	CrTable.ApplyLogOnInfo(crtableLogoninfo);
    }
    foreach (ReportDocument subreport in report.Subreports)
    {
    	foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
    	{
    		crtableLogoninfo = CrTable.LogOnInfo;
    		crtableLogoninfo.ConnectionInfo = crConnectionInfo;
    		CrTable.ApplyLogOnInfo(crtableLogoninfo);
    	}
    }

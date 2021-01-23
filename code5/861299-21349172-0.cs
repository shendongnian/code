        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        crConnectionInfo.ServerName = ".\sql2008";
        crConnectionInfo.DatabaseName = "ARM";
        crConnectionInfo.UserID = "sa";
        crConnectionInfo.Password = "test123";
        CrTables = report.Database.Tables ;
        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        {
            crtableLogoninfo = CrTable.LogOnInfo;
            crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            CrTable.ApplyLogOnInfo(crtableLogoninfo);
        }

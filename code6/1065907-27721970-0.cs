     public static object ConnForReport(ReportDocument objReport)
    {
    SqlConnection cn = null;
    cn = new SqlConnection(Properties.Settings.Default.CMScon);
    CrystalDecisions.Shared.TableLogOnInfo logOnInfo = null;
    logOnInfo = objReport.Database.Tables[0].LogOnInfo;
    logOnInfo.ConnectionInfo.ServerName = cn.DataSource;
    logOnInfo.ConnectionInfo.DatabaseName = cn.Database;
    logOnInfo.ConnectionInfo.UserID = "sa";
    logOnInfo.ConnectionInfo.Password = "SQLadmin";
    objReport.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
    return objReport;
    }

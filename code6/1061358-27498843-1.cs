    public static void ApplyLogOnInfo(ReportClass rpt)
        {
            TableLogOnInfo info = new TableLogOnInfo();
            info.ConnectionInfo.DatabaseName = Connect.sCurrentDatabase;
            for (int i = 0; i < rpt.Database.Tables.Count; i++)
            {
                rpt.Database.Tables[i].ApplyLogOnInfo(info);
            }
        }

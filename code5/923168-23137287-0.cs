    private void SetDBLogonToTables(CrystalDecisions.Shared.ConnectionInfo connectionInfo, CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument)
    {
        CrystalDecisions.CrystalReports.Engine.Tables tables = reportDocument.Database.Tables;
    
        foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
        {
            CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;
    
            tableLogonInfo.ConnectionInfo = connectionInfo;
            table.ApplyLogOnInfo(tableLogonInfo);
    
               //Following, did the trick! 
                try
                {
                    string strLocation = connectionInfo.DatabaseName + ".dbo." + table.Location.Substring(table.Location.LastIndexOf(".") + 1);
    
                    table.Location = strLocation;
                }
                catch (Exception ex)
                {//Catch 
                }
        }
    }

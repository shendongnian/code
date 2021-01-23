    DatabaseObject objData = new DatabaseObject();
    int ReportID = Convert.ToInt32(Request["ReportsID"]);
    objData.Query = " select DISTINCT R.ReportName,R.ID from Reports R inner      
    join ReportModuleCols RC on R.ID=RC.ReportID where RC.ReportID= " + ReportID   
            + " and R.ID= " + ReportID;
    string ReportName = Convert.ToString(objData.GetSingleValue());
    string storedProcedure = "";
    storedProcedure += " CREATE PROCEDURE spGet" + ReportName + ReportID + "\n";
    storedProcedure += " @Error Varchar(1000) output\n";
    storedProcedure += " AS \n";
    storedProcedure += " BEGIN \n";
    storedProcedure += " BEGIN TRY\n";
    storedProcedure += " SELECT ";
    objData.Query = " select ID,ReportID,ReportModuleID,ColsName,Type,ReportLevel,ParentID from ReportModuleCols where Type='d' and ReportID=" + ReportID;
    DataTable Displaytb = objData.GetTable();
    for (int d = 0; d < Displaytb.Rows.Count; d++)
    {
        storedProcedure += Displaytb.Rows[d]["ColsName"] + ",";
    }
    string DisplayParam = storedProcedure.Remove(storedProcedure.Length - 1, 1);
    DisplayParam += " FROM \n";
    objData.Query = "select ColsName from ReportModuleCols where Type='d' and ReportID=" + ReportID;
    DataTable inputtable = objData.GetTable();
    string TableColumn = "";
    for (int t = 0; t < inputtable.Rows.Count; t++)
    {
                string table = "";
                table = inputtable.Rows[t]["ColsName"].ToString();
                table = table.Substring(0, table.IndexOf("."));
                TableColumn += table + ",";
    }
    string[] TCols = TableColumn.Split(",".ToCharArray());
    string[] unique = TCols.Distinct().ToArray();
    foreach (string TableName in unique)
    {
                if (TableName != "")
                {
                    DisplayParam += TableName + ",";
                }
    }
    string SPQuery = DisplayParam.Remove(DisplayParam.Length - 1, 1) + "\n";
    SPQuery += " WHERE \n";
    objData.Query = " select ID,ReportID,ReportModuleID,ColsName,Type,ReportLevel,ParentID from ReportModuleCols where Type='j' and ParentID=0 and ReportID=" + ReportID;
    DataTable Join = objData.GetTable();
    for (int t = 0; t < Join.Rows.Count; t++)
    {
                objData.Query = " select ColsName from ReportModuleCols where Type='j' and ParentID=" + Convert.ToInt32(Join.Rows[t]["ID"]) + " and ReportID=" + ReportID;
                string ColJoin = objData.GetSingleValue() + "";
                SPQuery += Join.Rows[t]["ColsName"] + "=" + ColJoin + " AND  \n";
    }
    SPQuery += " 1 = 1 \n";
    SPQuery += " END TRY\n";
    SPQuery += " BEGIN CATCH\n";
    SPQuery += " SET @Error = ERROR_NUMBER() + ' ' + ERROR_MESSAGE();\n";
    SPQuery += " END CATCH\n";
    SPQuery += " END";
    objData.Query = SPQuery;
    objData.Execute();

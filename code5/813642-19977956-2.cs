    private void ReportParameter()
    {
        string reportName = "Test.rpt";
        string reportPath = Server.MapPath(String.Concat("~/reports/", reportName));
        string serverName = System.Configuration.ConfigurationManager.AppSettings["db"].ToString();
        string databaseName = String.Empty;
        string userId = Session["USERNAME"].ToString();
        string password = Session["PASSWORD"].ToString();
        if (File.Exists(reportPath))
        {
            ReportDocument reportDoc = new ReportDocument();
            reportDoc.Load(reportPath);
            foreach (ParameterField paramField in reportDoc.ParameterFields)
            {
                paramField.CurrentValues.Clear();
            }
            reportDoc.SetDatabaseLogon(userId, password, serverName, databaseName);
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.Type = ConnectionInfoType.SQL;
            crConnectionInfo.AllowCustomConnection = true;
            crConnectionInfo.IntegratedSecurity = false;
            crConnectionInfo.ServerName = serverName;
            crConnectionInfo.DatabaseName = databaseName;
            crConnectionInfo.UserID = userId;
            crConnectionInfo.Password = password;
            this.ApplyConnection(reportDoc, crConnectionInfo);
            this.crvRelatorio.EnableParameterPrompt = true;
            this.crvRelatorio.ReportSource = reportDoc;
            this.crvRelatorio.RefreshReport();
        }
        else
        {
            this.divHeader.Visible = true;
            this.ltrTitulo.Text = String.Concat("Relatório não foi encontrado ");
        }
    }
	
	private void ApplyConnection(ReportDocument report, ConnectionInfo connectionInfo)
    {
        this.ApplyLogOnInfo(report, connectionInfo);
        this.ApplyLogOnInfoForSubreports(report, connectionInfo);
    }
    private void ApplyLogOnInfo(ReportDocument reportDocument, ConnectionInfo connectionInfo)
    {
        foreach (CrystalDecisions.CrystalReports.Engine.Table tableTemp in reportDocument.Database.Tables)
        {
            if (tableTemp.Name.ToUpper().StartsWith("COMMAND"))
            {
            }
            TableLogOnInfo tableLogonInfo = tableTemp.LogOnInfo;
            tableLogonInfo.ConnectionInfo = connectionInfo;
            tableTemp.ApplyLogOnInfo(tableLogonInfo);
            bool b = tableTemp.TestConnectivity();
        }
    }
    private void ApplyLogOnInfoForSubreports(ReportDocument reportDocument, ConnectionInfo connectionInfo)
    {
        foreach (Section sectionTemp in reportDocument.ReportDefinition.Sections)
        {
            foreach (ReportObject reportObjectTemp in sectionTemp.ReportObjects)
            {
                if (reportObjectTemp.Kind == ReportObjectKind.SubreportObject)
                {
                    SubreportObject subreportObject = (SubreportObject)reportObjectTemp;
                    ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                    this.ApplyLogOnInfo(subReportDocument, connectionInfo);
                }
            }
        }
    }
    private ParameterFields ApplyParameters(string paramName, object paramValue)
    {
        ParameterFields paramFields = new ParameterFields();
        ParameterField paramField = new ParameterField();
        paramField.ParameterFieldName = paramName; // Crystal Report Parameter name.
        ParameterDiscreteValue pdvValue = new ParameterDiscreteValue();
        pdvValue.Value = paramValue;
        paramField.CurrentValues.Add(pdvValue);
        paramFields.Add(paramField);
        return paramFields;
    }

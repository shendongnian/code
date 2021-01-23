    using CrystalDecisions.Shared;
	using CrystalDecisions.CrystalReports.Engine;
	using CrystalDecisions.Web;
	public partial class ReportByCrystal : Page
	{
		//#region [ Page Events ]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				this.ReportParameter();
			}
			catch (Exception exc)
			{
				
			}
			if (!IsPostBack)
			{
			}
		}
		//#endregion
		//#region [ Methods ]
		/// <summary>
		/// 
		/// </summary>
		private void ReportParameter()
		{
			string reportName = "ReportName.rpt"
			string reportPath = Server.MapPath(String.Concat("~/reports/source/", reportName));
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
				this.crvCrystalReport.EnableParameterPrompt = true;
				this.crvCrystalReport.ReportSource = reportDoc;
				this.crvCrystalReport.RefreshReport();
			}
			else
			{
				this.ltrTitulo.Text = String.Concat("Report not found.");
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="report"></param>
		/// <param name="connectionInfo"></param>
		private void ApplyConnection(ReportDocument report, ConnectionInfo connectionInfo)
		{
			this.ApplyLogOnInfo(report, connectionInfo);
			this.ApplyLogOnInfoForSubreports(report, connectionInfo);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reportDocument"></param>
		/// <param name="connectionInfo"></param>
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reportDocument"></param>
		/// <param name="connectionInfo"></param>
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
	}

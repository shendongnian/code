        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var reportDataSource = new ReportDataSource
                {
                    // Must match the DataSource in the RDLC
                    Name = "SomeReportDataSet",
                    Value = Session["ReportData"]
                };
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
        }

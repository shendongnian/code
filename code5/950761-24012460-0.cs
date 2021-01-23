    private void LoadReport()
        {
            frmCheckWeigher rpt = new frmCheckWeigher();
            CryRe_DailyBatch report = new CryRe_DailyBatch();
            DataSet1TableAdapters.DataTable_DailyBatch1TableAdapter ta = new CheckWeigherReportViewer.DataSet1TableAdapters.DataTable_DailyBatch1TableAdapter();
            DataSet1.DataTable_DailyBatch1DataTable table = ta.GetData(clsLogs.strStartDate_rpt, clsLogs.strBatchno_Rpt, clsLogs.cmdeviceid); // Data from Database
            DataTable dt = GetImageRow(table, "Footer.Jpg");
            report.SetDataSource(dt);
            crv1.ReportSource = report;
            crv1.Refresh();
 
        }

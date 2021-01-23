    // in DAO
    public List<ReportCell> GetReportCells(DataTable table)
    {
        return ReportCell.ConvertTableToCells(table);
    }    
    
    // in aspx.cs
    ReportViewer_main.LocalReport.ReportPath = Server.MapPath("~/RDLC/Report_main.rdlc");
    ReportViewer_main.LocalReport.DataSources.Add(
        new ReportDataSource("DataSet1", dao.GetReportCells(tableGroupByMonth)));
    ReportViewer_main.LocalReport.Refresh();

           using System.Drawing.Printing;
           using Crystal Decisions.CrystalReports.Engine;
           using Crystal Decisions.Shared;
           protected void Page_Load(object sender, EventArgs e)
           {
             void();
           }
           public void()
           {
             try
            {
             ReportDocument crystalReport = new ReportDocument();
             crystalReport.Load(Server.MapPath("~/CrystalReport2.rpt"));
             DataSet dsCustomers = GetData("select * from visitor_details where  id ='" + Session["sessionvid"] + "' and  plant ='" + Session["sessionplant"] + "'");
             DataTable dataTable = dsCustomers.Tables[0];   crystalReport.Database.Tables["visitor_details"].SetDataSource((DataTable)dataTable);
              CrystalReportViewer2.ReportSource = crystalReport;
              CrystalReportViewer2.Zoom(100);
              //crystalReportViewer1.ExportReport() ;
              CrystalReportViewer2.RefreshReport();
              crystalReport.PrintOptions.PrinterName = GetDefaultPrinter();
              crystalReport.PrintToPrinter(1, false, 0, 0);
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('connect printer settings')</script>");
            }
}

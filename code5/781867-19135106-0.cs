        protected void Print_Click(object sender, EventArgs e)
        {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;
        string devinfo = "<DeviceInfo><ColorDepth>32</ColorDepth><DpiX>350</DpiX><DpiY>350</DpiY><OutputFormat>PDF</OutputFormat>" +
               "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>0.5in</MarginLeft>" +
                 "  <MarginRight>0in</MarginRight>" +
                 "  <MarginBottom>0in</MarginBottom>" +
               "</DeviceInfo>";
        // Setup the report viewer object and get the array of bytes
        ReportViewer viewer = new ReportViewer();
        viewer.ProcessingMode = ProcessingMode.Local;
        viewer.LocalReport.ReportPath = Server.MapPath("~/Installments_Report.rdlc");
        DataView dv = new DataView();
        DataTable dt = new DataTable();
        dv = (System.Data.DataView)SqlDataSource1.Select(System.Web.UI.DataSourceSelectArguments.Empty);
        dt = dv.ToTable();
        viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
        byte[] bytes = viewer.LocalReport.Render("PDF", devinfo, out mimeType, out encoding, out extension, out streamIds, out warnings);
        // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
        string path =Server.MapPath("Print_Files") ;
        Random rnd = new Random();
        int month = rnd.Next(1, 13); // creates a number between 1 and 12
        int dice = rnd.Next(1, 7); // creates a number between 1 and 6
        int card = rnd.Next(9); // creates a number between 0 and 51
        string file_name = "Installments" + "List" + month+dice+card+".pdf"; //save the file in unique name 
        //3. After that use file stream to write from bytes to pdf file on your server path
        FileStream file = new FileStream(path + "/" + file_name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        file.Write(bytes, 0, bytes.Length);
        file.Dispose();
        //4.path the file name by using query string to new page 
        Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "Print.aspx?file="+file_name));
         }

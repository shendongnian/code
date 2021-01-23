    try
    {
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;
        var reportViewer1 = new ReportViewer();
        reportViewer1.ProcessingMode = ProcessingMode.Local;
        reportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CGReports.rdlc");
        var dsCustomers = new DataSet();
        using (var client = ServiceClient<ILoaneeStatusManager>.Create(ObjectConstants.LoaneeStatusManager))
        {
            DataTable dt = client.Instance.GetAllLoaneeStatusByCGdanForReport(CGDANNo);
            //   DataTable dt = new DataTable();
            //   dt.Clear();
            //   dt.Columns.Add("MLIFees");
            //   dt.Columns.Add("TranscationAmount");
            //   dt.Columns.Add("CreatedDate");
            //   dt.Columns.Add("AfterDate");
            //   DataRow row = dt.NewRow();
            //row["MLIFees"] = statusDtos[0].MLIFees;
            //row["TranscationAmount"]=statusDtos[0].SanctionedAmount;
            //row["CreatedDate"]=statusDtos[0].CreatedDate;
            //row["AfterDate"] = statusDtos[0].AfterDate;
            //dt.Rows.Add(row);
            dsCustomers.Tables.Add(dt.Copy());
            var datasource = new ReportDataSource("DataSet1", dsCustomers.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            //RDLC FILE CAN CONTAIN MULTIPLE DATASOURCES WITHOUT
            reportViewer1.LocalReport.DataSources.Add(datasource);
            byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            // CODE TO SAVE THE REPORT FILE ON SERVER
            if (File.Exists(Server.MapPath("~/Documents/CGDANNo_" + CGDANNo + ".pdf")))
            {
                File.Delete(Server.MapPath("~/Documents/CGDANNo_" + CGDANNo + ".pdf"));
            }
            FileStream fileStream = new FileStream(Server.MapPath("~/Documents/CGDANNo_" + CGDANNo + ".pdf"), FileMode.Create);
            for (int i = 0; i < bytes.Length; i++)
            {
                fileStream.WriteByte(bytes[i]);
            }
            fileStream.Close();
        }
    }
    catch (Exception ex)
    {
        ex.ToString();
    }

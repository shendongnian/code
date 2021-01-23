            this.DataTable1TableAdapter.Fill(this.reportdataset.DataTable1, ponum);
            DataTable dt = new DataTable();
            dt = DataTable1TableAdapter.GetData(ponum);
            Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt);
            
            reportViewer1.LocalReport.DataSources.Add(rprtDTSource);
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string filename = "Purchase Requisition " + ponum.ToString() + ".pdf";
            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();               
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return filename;

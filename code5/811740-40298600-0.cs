            int id =Convert.ToInt32(txtID.Text);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
            
            DataTable dt = GridView1.DataSourceObject;
            if (dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DatasetName", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }

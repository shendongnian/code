        using System.Data.SqlClient;
        public void GetDataFromStoredProcedure(object sender, EventArgs e)
        {
            SqlConnection SConnect = new SqlConnection();
            SqlCommand SCommand = new SqlCommand();
            SqlDataAdapter SAdaptor = new SqlDataAdapter();
            SConnect.Open();
            // in the next line you execute your stored procedure with form controls content
            SCommand.CommandText = "exec [dbo].[MJTestProc] '" + RadioButton1.Text + "' , '" + DatePicker1.Text + "' , '" + DatePicker2.Text + "'";
            DataTable dt = new DataTable();
            SAdaptor.Fill(dt);
            SConnect.Close();
            //here you can assign dt content to a control. Below code is a sample to assign data to the reportviewer
            Microsoft.Reporting.WinForms.ReportDataSource myreportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            try
            {
                myreportDataSource.Name = "DataSource name in rdlc file";
                myreportDataSource.Value = dt;
                this.reportViewer1.LocalReport.DataSources.Add(myreportDataSource);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "YourNamespace.YourRDLCfilename.rdlc";
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
            }
        }

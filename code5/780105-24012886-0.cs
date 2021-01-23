    private void ViewR_Load(object sender, EventArgs e)
        {
            CrystalReportP objRpt;
            // Creating object of our report.
            objRpt = new CrystalReportP();
            DataSetPatient ds = new DataSetPatient(); // .xsd file name
            DataTable dt = DBHandling.GetPatient();
            dt = GetImageRow(dt, "YourImageName.Jpg"); 
            ds.Tables[0].Merge(dt);
            objRpt.SetDataSource(ds);            
            crystalReportViewer1.ReportSource = objRpt;          
        }       

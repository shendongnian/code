    private void btnGo_Click(object sender, EventArgs e)
            {
                CrReport2 objRpt = new CrReport2();
                string query = "Select Name,Number from tblInfo";  //Your sql query
                SqlCeConnection conn =
                    new SqlCeConnection(
                        @"Data Source=|DataDirectory|\myDB.sdf;Persist Security Info=False"); //Your connection
    
                SqlCeDataAdapter adepter = new SqlCeDataAdapter(query, conn);
                DsReport Ds = new DsReport(); //DsReport is my dataset
    
                adepter.Fill(Ds, "customer"); //customer is my datatable in dataset
    
                objRpt.SetDataSource(Ds);
                crystalReportViewer1.ReportSource = objRpt;
            }

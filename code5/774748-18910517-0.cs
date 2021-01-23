            private void Form2_Load(object sender, EventArgs e)
        {
            RST_DBDataContext db = new RST_DBDataContext();
            var d = (from s in db.TblSpareParts
                                        select new {  
														s.SPartName?? DBNull.Value, 
														s.SPartCode?? DBNull.Value, 
														s.ModelID ?? DBNull.Value, 
														s.SPartLocation ?? DBNull.Value,  
														s.SPartActive ?? DBNull.Value, 
														s.SPartSalePrice ?? DBNull.Value, 
													}).ToArray();
            CrystalReport1 c = new CrystalReport1();
            c.SetDataSource(d);
            crystalReportViewer1.ReportSource = c;
        } 

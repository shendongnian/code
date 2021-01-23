    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    dt = this.dv.ToTable("Table");
    ds.Tables.Add(dt);
    rd.Load("CrystalReport1.rpt");
    rd.SetDataSource(ds);
    crystalReportViewer2.ReportSource = rd;
    crystalReportViewer2.Show();    
        

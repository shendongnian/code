     CrystalReport1 report = new CrystalReport1();
                DataSet1TableAdapters.DataTable1TableAdapter table = new DataSet1TableAdapters.DataTable1TableAdapter();
                DataSet1.DataTable1DataTable tables = table.GetData();
                report.SetDataSource(tables.DefaultView);
        
                crystalReportViewer1.ReportSource = report;
        
               // crystalReportViewer1.Refresh();//Remove this line

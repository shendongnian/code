		testdbDataSet ds = new testdbDataSet();
		
		//FETCH FROM ANYWHERE TO a DataTable
		DataTable _DtFrmDBPrd = new DataTable();
		DataTable _DtFrmDBRgn = new DataTable();
		
		_DtFrmDBPrd = GetDataFrmDBPrd();//Filling the DataTable From DB are any where..
		_DtFrmDBRgn = GetDataFrmDBRgn();
		
		ds.Products.Merge(_DtFrmDBPrd);//Both the Data Table should have the same column name and Data Type
		ds.Region.Merge(_DtFrmDBRgn);
		
        ReportDocument reportDoc = new ReportDocument();
        reportDoc.FileName = "CrystalReport1.rpt";
        reportDoc.SetDataSource(ds);
        crystalReportViewer1.ReportSource = reportDoc;
        crystalReportViewer1.Show();

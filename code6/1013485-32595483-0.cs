    ModelRealEstate.DB_RealEstateEntities objdb = new ModelRealEstate.DB_RealEstateEntities();
            var rows = objdb.Tbl_Property.Where(x => x.Adress.Contains(mtxbxRprt.Text)).ToList();
            reportViewer1.LocalReport.ReportPath = ("Report1.rdlc");
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("P2", mtxbxRprt.Text));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", rows));
            reportViewer1.RefreshReport();

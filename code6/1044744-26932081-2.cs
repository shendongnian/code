    var ds = new ProperDataSource();
    foreach(GridViewRow row in gvSample.Rows)
    {
        dRow data = new dRow();
        foreach(TableCell cell in row.Cells)
        {
            ds.Add("column1", cell.Text);
        }
        ds.Add(dRow);
    }
    string csv = ToCSV(ds); //gv.DataSource is null, DatasourceID aswell
            Response.ContentType = "application/csv";
            Response.AddHeader("content-disposition", "attachment; filename=file.csv");
            Response.Write(csv);
            Response.End();  

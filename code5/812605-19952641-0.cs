    string filename = Path.GetFileName(FileUpload1.FileName);
    
    DataSet ds = new DataSet();
    string path = Server.MapPath("~/Publisher/ExcelFiles/" + filename);
            FileUpload1.SaveAs(path);
    OleDbConnection myCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;
    DataSource=" + path + ";Extended Properties=Excel 12.0;");
    OleDbCommand myComm = new OleDbCommand("select * from [GIRLS$] ", myCon);
    OleDbDataAdapter da = new OleDbDataAdapter(myComm);
    da.Fill(ds);
    GridView1.DataSource = ds;
    GridView1.DataBind();

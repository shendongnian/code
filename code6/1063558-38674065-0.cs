    string conStr="";
    switch (Extension)
    {
        case ".xls": //Excel 97-03
            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                     .ConnectionString;
            break;
        case ".xlsx": //Excel 07
            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                     .ConnectionString;
            break;
    }
 
    //Get the Sheets in Excel WorkBoo
    conStr = String.Format(conStr, FilePath, isHDR);
    OleDbConnection connExcel = new OleDbConnection(conStr);
    OleDbCommand cmdExcel = new OleDbCommand();
    OleDbDataAdapter oda = new OleDbDataAdapter();
    cmdExcel.Connection = connExcel;
    connExcel.Open();
 
    //Bind the Sheets to DropDownList
    ddlSheets.Items.Clear(); 
    ddlSheets.Items.Add(new ListItem("--Select Sheet--", ""));    
    ddlSheets.DataSource=connExcel
             .GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    ddlSheets.DataTextField = "TABLE_NAME";
    ddlSheets.DataValueField = "TABLE_NAME";
    ddlSheets.DataBind();
    connExcel.Close();
    txtTable.Text = "";
    lblFileName.Text = Path.GetFileName(FilePath);
    Panel2.Visible = true;
    Panel1.Visible = false;
}
 

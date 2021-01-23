      protected void btnImport_Click(object sender, EventArgs e)
        {
            ArrayList alist = new ArrayList();
            string connString = "";
            string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            string fileBasePath = Server.MapPath("~/Files/");
            string fileName = Path.GetFileName(this.fileuploadExcel.FileName);
            string fullFilePath = fileBasePath + fileName;
            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilePath +
                              ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFilePath +
                             ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }
            if (fileuploadExcel.HasFile)
            {
                string query = "SELECT [UserName],[Education],[Location] FROM [Sheet1$]";
                OleDbConnection conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //Assigning dataset table data to GridView Control
                Session["griddata"] = ds.Tables[0];
                System.Data.DataTable dtt = (System.Data.DataTable)Session["griddata"];  //griddata is the gridview data from another page        
                var res = (from f in dtt.AsEnumerable()
                           select f.Field<string>("Location")
                    );
                foreach (string s in res.AsEnumerable())
                {
                    alist.Add(s);
                }
                Session["dropdownvalue"] = alist;
                grvExcelData.DataSource = Session["griddata"];
                grvExcelData.DataBind();
                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

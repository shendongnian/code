            public ActionResult Export(string QCode = "")
        {
            if (QCode != "")
            {
                GridView gv = new GridView() { AutoGenerateColumns = true };
                string strSQL = "GetExcelExtract '" + QCode + "'";
                DataSet DS = new DataSet();
                SqlConnection SQLConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.AppSettings["ConnectionString"]);
                SqlCommand SQLCmd = new SqlCommand(strSQL, SQLConn);
                SQLCmd.CommandTimeout = 90;
                SqlDataAdapter SQlAdpt = new SqlDataAdapter();
                SQlAdpt.SelectCommand = SQLCmd;
                SQLConn.Open();
                SQlAdpt.Fill(DS);
                SQLConn.Close();
                gv.DataSource = DS;
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=ExportQuestion_" + QCode + ".xls");
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.ContentType = "application/ms-excel";
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                gv.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            return View();
        }

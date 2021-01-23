    public DataTable gettable(int SponsorIDNum)
            {
            SqlConnection thisConnection = new SqlConnection("server=.;database=local;Integrated Security=SSPI")
            string query = "select * from tbluser where companyID =" +companyID;
            SqlDataAdapter ad = new SqlDataAdapter(query, thisConnection);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Categories");
            DataTable dt = ds.Tables[0];
            return dt;
            }
        protected void Member_Click(object sender, EventArgs e)
            {
            try
                {
                var pck = new OfficeOpenXml.ExcelPackage();
                var ws = pck.Workbook.Worksheets.Add("Name of the Worksheet");
                // get your DataTable
                var tbl = gettable(0);
                ws.Cells["A1"].LoadFromDataTable(tbl, true, OfficeOpenXml.Table.TableStyles.Medium6);
                var dataRange = ws.Cells[ws.Dimension.Address.ToString()];
                dataRange.AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=NameOfExcelFile.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                }
            catch (Exception ex)
                {
                // log exception
                throw;
                }
            Response.End();
          
            }
        protected void Sponsor_Click(object sender, EventArgs e)
            {
            try
                {
                var pck = new OfficeOpenXml.ExcelPackage();
                var ws = pck.Workbook.Worksheets.Add("Name of the Worksheet1");
                // get your DataTable
                var tbl = gettable(1);
                ws.Cells["A1"].LoadFromDataTable(tbl, true, OfficeOpenXml.Table.TableStyles.Medium6);
                
                var dataRange = ws.Cells[ws.Dimension.Address.ToString()];
                dataRange.AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=NameOfExcelFile.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                }
            catch (Exception ex)
                {
                // log exception
                throw;
                }
            Response.End();
            }

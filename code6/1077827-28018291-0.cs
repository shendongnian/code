    string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(fuFile.PostedFile.FileName);
            fuFile.SaveAs(excelPath);
            string conString = string.Empty;
            string extension = Path.GetExtension(fuFile.PostedFile.FileName);
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conString = string.Format(conString, excelPath);
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                DataTable dtExcelData = new DataTable();
                //OPTIONAL
                dtExcelData.Columns.AddRange(new DataColumn[3] { new DataColumn("Emp_Id", typeof(int)),
                new DataColumn("Emp_Name", typeof(string)),
                new DataColumn("Emp_Salary",typeof(decimal)) });
                using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                }
                excel_con.Close();
                string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        sqlBulkCopy.DestinationTableName = "dbo.tblEmps";
                        //OPTIONAL
                        sqlBulkCopy.ColumnMappings.Add("Emp_Id", "Emp_Number");
                        sqlBulkCopy.ColumnMappings.Add("Emp_Name", "Emp_Name");
                        sqlBulkCopy.ColumnMappings.Add("Emp_Salary", "Emp_Salary");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                    }
                }
            }

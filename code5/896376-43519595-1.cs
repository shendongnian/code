    private void FillGrid(string FilePath, string Extension)
    {
            
            string conStr = "";
            DataTable dt = new DataTable();
           
            /*Add below Commented in Webconfig*/
             /*   <add name ="Excel03ConString"
         connectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};
                         Extended Properties='Excel 8.0;HDR={1}'"/>
              <!--connectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};
                         Extended Properties='Excel 8.0;HDR={1}'"/>-->
    <add name ="Excel07ConString"
         connectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};
                         Extended Properties='Excel 8.0;HDR={1}'"/>
              * */
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, "Yes");
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            cmdExcel.Connection = connExcel;
            try
            {
                int m = 1;
                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();
                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                //oda.SelectCommand = cmdExcel;
                //oda.Fill(dt);
                // connExcel.Close();
                DataTable myColumns = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, SheetName, null });
                foreach (DataRow dtRow in myColumns.Rows)
                {
                    if (dtRow["COLUMN_NAME"].ToString() == "Sr No" && dtRow["ORDINAL_POSITION"].ToString() == "1")
                    {
                        m++;
                    }
                    else if (dtRow["COLUMN_NAME"].ToString() == "Task Name" && dtRow["ORDINAL_POSITION"].ToString() == "2")
                    {
                        m++;
                    }
                }
                /*column count in excel*/
                if (m < 2)
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "Selected file is not in required template format.";
                    return;
                }
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();
            }
            catch (Exception ex)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Selected file is not in required template format.";
                return;
            }
            DataTable dt_grd1 = new DataTable();
            DataRow drnewrow = null;
           
                //upload_plan = 1;
                foreach (DataRow dtRow in dt.Rows)
                {
                    if (dtRow["Sr No"].ToString() == "" && dtRow["Task Name"].ToString() != "")
                    {
                                dt_grd1.Columns.Add(new DataColumn("ID", typeof(string)));
                                dt_grd1.Columns.Add(new DataColumn("TASK_NAME", typeof(string)));    
                    }
   
                        try
                        {
                            drnewrow = dt_grd1.NewRow();
                            drnewrow["ID"] = "";
                            drnewrow["TASK_NAME"] = dtRow["Task Name"].ToString();
                            
                            dt_grd1.Rows.Add(drnewrow);
                        }
                        catch (Exception ex)
                        {
                            //lblError.Visible = true;
                            ////lblError.Text = ex.Message;// "Authentication failed. Please try later.";
                            //lblError.Text = DataInteraction.Constants.EXCEPTION;
                        }
                    }
                /*Using Linq Find same TASK_NAME present in Excel*/
                if (dt_grd1.Rows.Count >= 1)
                {
                    var Taskresult = from c in dt_grd1.AsEnumerable()
                                     group c by new
                                     {
                                         TaskName2 = c.Field<dynamic>("TASK_NAME"),
                                     } into g
                                     where g.Count() > 1
                                     select new
                                     {
                                         g.Key.TaskName2,
                                         //  g.Key.Pin,
                                         Noofrec = g.Count()
                                     };
                    if (Taskresult.ToList().Count > 0)
                    {
                        lblErrMsg.Visible = true;
                        div_err_log.Visible = false;
                        lblErrMsg.Text = "Task with same Name not allowed.";
                        return;
                    }
                }
                grdTaskDataCat1.DataSource = dt_grd1;
                grdTaskDataCat1.DataBind();
               
                /*End 13th Jan'17*/
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Please confirm the details uploaded and press save to complete the upload of Bid plan.";
                return;
    
    }

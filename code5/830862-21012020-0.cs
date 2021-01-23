        ClearGrid();
        fyid =Convert.ToInt32(ddlYear.SelectedValue);
        dt.Clone();
        try
        {
            Session["datatable"] = null;
            dt = obj.AttendanceReport_Employee(fyid, Convert.ToInt32(ddlMonth.SelectedValue),Convert.ToString(EmpID));
            if (dt.Rows.Count > 0)
            {
                divGrd.Visible = true;
                btnExcel.Visible = true;
                btnPrint.Visible = true;
                gvAttendanceReport.Visible = true;
                int count = dt.Columns.Count;
                this.gvAttendanceReport.DataSource = dt;
                this.gvAttendanceReport.DataBind();
                int i = 0;            
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        DataColumn col = new DataColumn();
                        col = dt.Columns[j];
                        BoundField field = new BoundField();
                        field.DataField = col.ColumnName;
                        string text = col.ColumnName;
                        if (i != 0 && i != 1 && col.ColumnName!="Total Present" && col.ColumnName!="Total Absent" && col.ColumnName!="Total HalfDay" && col.ColumnName!="Total Late" && col.ColumnName!="Total Holiday")
                        {
                            field.HeaderText = text.Substring(0, 2);
                        }
                        else
                        {
                            field.HeaderText = text;
                        }
                        gvAttendanceReport.Columns.Add(field);
                        i++;                       
                    }               
                gvAttendanceReport.AutoGenerateColumns = false;
                gvAttendanceReport.DataSource = dt; //a DataTable of your choice
                gvAttendanceReport.DataBind();
                Session["datatable"] = dt;
               
            }
            else
            {
               
                btnExcel.Visible = false;
                btnPrint.Visible = false;
            }
        }
        catch(Exception ex)
        {
           gvAttendanceReport.DataSource = dt;
           gvAttendanceReport.DataBind();
           
           btnExcel.Visible = false;
           btnPrint.Visible = false;
        }
    }

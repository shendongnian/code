      protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = CalendarMain.SelectedDate;
            string SportType = ddlSportType.SelectedItem.ToString();
            string distance = ddlDistance.SelectedItem.ToString();
        
            
        	DataTable dt = new DataTable();
        
            dt.Columns.Add("Activity");
            dt.Columns.Add("Duration");
            dt.Columns.Add("status");
            dt.Columns.Add("Time_Start");
            dt.Columns.Add("Plan_ID");
        
        
            DataTable dt1 = wp.addPlanDetailDataRow(dt);
        
            gvActivityList.DataSource = dt;
            gvActivityList.DataBind();
        }
        public DataTable addPlanDetailDataRow(DataTable dt)
        {
            plan wp = new plan();
            wp.Time_Start = selectedDate;
            wp.Duration = distance;
            wp.Activity = SportType;
             if (ViewState["Datatable"] != null)
            {
                dt = (DataTable)ViewState["Datatable"];
            }
            ViewState["Datatable"] = dt;
            DataRow dr = dt.NewRow();
        
        
        
            DataRow newRow = dt.NewRow();
        
            dt.Rows.Add(newRow);
        
            return dt;
        }

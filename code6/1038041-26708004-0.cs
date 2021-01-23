    if (e.Row.RowType = DataControlRowType.DataRow)
         {
            if (GridView1.EditIndex == e.Row.RowIndex)
            {     
            DropDownList DropdownList1 = (DropDownList)e.Row.FindControl("DropdownList1");
            ShadingAnalysisDataSetTableAdapters.tbl_AutoAssignCadTeamTableAdapter at;
            at = new ShadingAnalysisDataSetTableAdapters.tbl_AutoAssignCadTeamTableAdapter();
            DataTable dt = new DataTable();
            dt=at.GetUpdateTeam();
            DropdownList1.DataSource = dt;
            DropdownList1.DataTextField = "Assigned_Team";
            DropdownList1.DataValueField = "Assigned_Team";
            DropdownList1.DataBind();
            DropdownList1.Items.FindByValue((e.Row.FindControl("Label1") as Label).Text).Selected = true;
            }
          }

        protected void StaffTypeGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow ||
                e.Row.RowIndex != StaffTypeGridView.EditIndex) return;
            var staffType = (StaffType)e.Row.DataItem;
            var appCode = staffType.AppCode;
            var ddl = (DropDownList) e.Row.FindControl(ddlName);
            if (!string.IsNullOrEmpty(value) &&
                ddl.Items.FindByValue(value) == null)
            {
                ddl.Items.Add(new ListItem
                {
                    Value = value,
                    Text = value + " (Deleted)"
                });
            }
            ddl.SelectedValue = value;
        }

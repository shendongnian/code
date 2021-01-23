        protected void StaffTypeGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var staffType = (StaffType)e.Row.DataItem;
            var appCode = staffType.AppCode;
            DisplayLabelField(e, "AppCodeLabel", appCode);
            DisplayDropDownListField(e, "AppCodeDropDownList", appCode);
        }
        private void DisplayLabelField(GridViewRowEventArgs e, string labelName, string value)
        {
            var label = (Label) e.Row.FindControl(labelName);
            if (label != null)
                label.Text = value;
        }
        private void DisplayDropDownListField(GridViewRowEventArgs e, string ddlName, string value)
        {
            var ddl = (DropDownList) e.Row.FindControl(ddlName);
            if (ddl != null)
            {
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
        }

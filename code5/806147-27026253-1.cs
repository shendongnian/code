        protected void StaffTypeGridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            // e.Row.DataItem might be null if for example Cancel is pressed
            if (!(e.Row.RowState == DataControlRowState.Edit && e.Row.DataItem != null)) return;
            var staffType = (StaffType) e.Row.DataItem;
            var normalRoleDropDownList = (DropDownList) e.Row.FindControlRecursive("NormalRoleDropDownList");
            if (!string.IsNullOrEmpty(staffType.NormalRole) &&
                normalRoleDropDownList.Items.FindByValue(staffType.NormalRole) == null)
            {
                normalRoleDropDownList.Items.Add(new ListItem
                {
                    Value = staffType.NormalRole,
                    Text = staffType.NormalRole + " (Deleted)"
                });
            }
        }

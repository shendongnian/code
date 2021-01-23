                // Find index of selected row which would be group/block row. Add 1 to find first section row in that block/group.
            var index = dgGroup.Items.IndexOf(dgGroup.SelectedItem) + 1;
            // Starting from the index found above loop through section rows untill you find blank row which can be identified by checking if "Group Name" does not have any value.
            for (int i = index; i < dgGroup.Items.Count; i++)
            {
                if (((DataRowView)dgGroup.Items[i]).Row.ItemArray[1].ToString().Trim() == string.Empty)
                {
                    return;
                }
                else
                {
                    // Add data to textbox.
                }
            }

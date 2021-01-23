    foreach (DataGridItem row in vjezbeGrid.Items)
            {
                if (row.ItemType == ListItemType.Item)
                {
                    CheckBox chkVjezba = (CheckBox)row.FindControl("chkVjezba");
    
                    if (chkVjezba.Checked)
                    {
                        //something
                    }
                }
    
            }

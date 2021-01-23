    GridViewRow row = GridView1.FooterRow;
        RadComboBox rcbDept = row.FindControl("rcbDept") as RadComboBox;
        foreach (RadComboBoxItem item in rcbDept.Items)
        {
            CheckBox chk1 = (CheckBox)item.FindControl("chk1");
            HiddenField hdnColumn = (HiddenField)item.FindControl("hdnColumn");
            if (chk1.Checked)
            {
                //Item checked
                string str = hdnColumn.Value;
                //Access hiddedn field vale here
            }
            else
            {
                //Item Unchecked
                string str = hdnColumn.Value;
                //Access hiddedn field vale here
            }
        }
    

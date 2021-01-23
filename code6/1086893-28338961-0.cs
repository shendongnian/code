     protected void BLOCKCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            ListViewItem itm = (ListViewItem)checkbox.NamingContainer;
            if (lstview1.EditIndex == itm.DisplayIndex)
            {
               
                (itm.FindControl("NAMETextBox") as TextBox).ReadOnly = true;
            }
        }

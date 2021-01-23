    private void dgvMyGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            ComboBox cbDGVCell = e.Control as ComboBox;
            if (spouseActive == true)
            {
               cell.Items.Add("<spouse>");     
               cell.Items.Add("Joint");
               Debug.WriteLine("added");
            }
            else
            {  
               cell.Items.Remove("<spouse>");       
               cell.Items.Remove("Joint");
               Debug.WriteLine("removed");
            }
        }
    }

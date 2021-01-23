    private void dgvDVDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dgvDVDetails.CurrentCell.ColumnIndex == 1)
        {
            TextBox prodCode = e.Control as TextBox;
            if (prodCode != null)
            {
                prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                prodCode.AutoCompleteCustomSource = ClientListDropDown();
                prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
    
            }
        }
       else
       {
           TextBox prodCode = e.Control as TextBox;
           if (prodCode != null)
            {
                prodCode.AutoCompleteMode = AutoCompleteMode.None;
            }
       }
    }

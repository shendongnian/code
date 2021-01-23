    private void dgvMyGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            ComboBox cbDGVCell = e.Control as ComboBox;
            cbDGVCell.SelectedIndexChanged += cbDGVCell_SelectedIndexChanged;
        }
    }

    private void GridSellProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
         if (GridSellProducts.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
         {
              ComboBox comboBox = e.Control as ComboBox;
              comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
         }
    }

    private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
         if (e.AddedCells.Count > 0 && !this.dataGrid.IsReadOnly)
         {
             this.dataGrid.BeginEdit();
         }
    }

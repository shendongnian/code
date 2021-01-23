    private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        if (e.AddedCells.Count == 0)
            this.textBox.SetBinding(TextBox.TextProperty, (string) null);
        else
        {
            var selectedCell = e.AddedCells.First();
            // Assumes your header is the same name as the field it's bound to
            var binding = new Binding(selectedCell.Column.Header.ToString())
            {
                Mode = BindingMode.TwoWay,
                Source = selectedCell.Item,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            this.textBox.SetBinding(TextBox.TextProperty, binding);
        }
    }

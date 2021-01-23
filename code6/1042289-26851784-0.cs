    private void DataGrid_OnPreparingCellForEdit(
        object sender,
        DataGridPreparingCellForEditEventArgs e)
    {
        if (e.Column == YourColumn) // replace with an appropriate comparison
        {
            var element = e.EditingElement;
            element.Dispatcher.BeginInvoke(
                DispatcherPriority.Input,
                new Action(() => element.MoveFocus(
                    new TraversalRequest(FocusNavigationDirection.First))));
        }
    }

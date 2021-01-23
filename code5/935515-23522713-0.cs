     protected override void OnCanExecuteBeginEdit(System.Windows.Input.CanExecuteRoutedEventArgs e)
    {
        var hasCellValidationError = false;
        var hasRowValidationError = false;
        const BindingFlags bindingFlags =
            BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance;
        var cellError= this.GetType().BaseType.GetProperty("HasCellValidationError", bindingFlags);
        var rowError = this.GetType().BaseType.GetProperty("HasRowValidationError", bindingFlags);
        if (cellError != null) 
            hasCellValidationError = (bool) cellErrorInfo.GetValue(this, null);
        if (rowError != null)
            hasRowValidationError = (bool) rowErrorInfo.GetValue(this, null);
        base.OnCanExecuteBeginEdit(e);
        if ((!e.CanExecute && hasCellValidationError) || (!e.CanExecute && hasRowValidationError))
        {
            e.CanExecute = true;
            e.Handled = true;
        }
    }

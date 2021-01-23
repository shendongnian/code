    IsKeyboardFocusWithinChanged="TextEdit_IsKeyboardFocusWithinChanged"
    private void TextEdit_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var textEdit = sender as TextEdit;
        var viewModel = DataContext as MyViewModel;
        if (textEdit != null)
        {
            if (!textEdit.IsKeyboardFocusWithin)
            {
                viewModel.MyCommandExecuted(null);
            }
        }
    }

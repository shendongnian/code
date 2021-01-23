    private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Up)
        {
            ApplicationCommands.Undo.Execute(null, (IInputElement)sender);
            return;
        }
        if (e.Key == Key.Down)
        {
            ApplicationCommands.Redo.Execute(null, (IInputElement)sender);
            return;
        }
    }

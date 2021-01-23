    private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (e.Delta > 0)
        {
            ScrollBar.LineDownCommand.Execute(null, e.OriginalSource as IInputElement);
        }
        if (e.Delta < 0)
        {
            ScrollBar.LineUpCommand.Execute(null, e.OriginalSource as IInputElement);
        }
        e.Handled = true;
    }

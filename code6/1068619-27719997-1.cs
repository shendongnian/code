    private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
    {
        if (this.GoBackCommand.CanExecute(null) && !e.Handled)
        {
            e.Handled = true;
            this.GoBackCommand.Execute(null);
        }
    }

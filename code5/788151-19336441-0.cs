    private void HandleUsernameKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Enter || e.PlatformKeyCode == 0x0A)
        {
            e.Handled = true;
            PasswordText.Focus();
        }
    }

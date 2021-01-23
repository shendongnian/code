    private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F && Keyboard.Modifiers == ModifierKeys.Control)
            {
                _searchWin.Visibility = System.Windows.Visibility.Visible;
                e.Handled = true;
            }
        }

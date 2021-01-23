    private void PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == 
            ModifierKeys.Control)
        {
           MessageBox.Show("CTRL + C was pressed");
        }
    }

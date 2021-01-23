    private void KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
    TextBox txt = (TextBox)sender;
    if (txt.Text.Contains('.'))
    {
        txt.Text = txt.Text.Replace(".", "");
        txt.SelectionStart = txt.Text.Length;
    }
    }

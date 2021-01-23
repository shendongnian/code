    private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Hide();
        e.Cancel = true;
        ShowInTaskbar = false;
    }
    private void LoginForm_DoubleClick(object sender, EventArgs e)
    {
        ShowInTaskbar = true;
        Show();
    }

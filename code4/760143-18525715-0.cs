    private void ButtonClick(object sender, EventArgs e)
    {
        Form aform = new Form();
        aform.Show();
        aform.FormClosing += FrmClosing;
        Hide();
    }
    private void FrmClosing(object sender, FormClosingEventArgs e)
    {
        Show();
    }

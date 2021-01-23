    public void HandleButtonClick(object sender, EventArgs e)
    {
        (sender as Button).Enabled = false;
        progressBar.Visible = true;
        //Some statements
        progressBar.Visible = false;
        (sender as Button).Enabled = true;
    }

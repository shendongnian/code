    private void DoTheButtonStuff(Button button)
    {
        button.Enabled = false;
        progressBar.Visible = true;
        // Do stuff here
        button.Enabled = true;
        progressBar.Visible = false;
    }

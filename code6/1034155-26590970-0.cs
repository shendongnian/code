    private void aButton_Click(object sender, EventArgs e)
    {
        this.Hide();
        secondform.Show();
        secondform.FormClosed += new FormClosedEventHandler(sf_FormClosed);
    }
    void sf_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit(); 
    }

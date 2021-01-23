    protected void btnSend_Click(object sender, EventArgs e)
    {
        string test = String.Empty;
        string[] words = txtText.Text.Split(' ');
        foreach (string word in words)
        {
            test += String.Format("\"" + word + "\" ");
    
        }
        lblText.Text = test;
    }

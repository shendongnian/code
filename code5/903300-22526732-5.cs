    protected void btnSend_Click(object sender, EventArgs e)
    {
        string[] words = txtText.Text.Split(' ');
        string test = String.Empty;
        foreach (string word in words)
        {
            test += word.Replace(word, '"' + word + '"');
        }
        lblText.Text = test.ToString();
    }

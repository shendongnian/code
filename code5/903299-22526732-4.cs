    protected void btnSend_Click(object sender, EventArgs e)
    {
        string[] words = txtText.Text.Split(' ');
        foreach (string word in words)
        {
            string test = word.Replace(word, '"' + word + '"');
        }
        lblText.Text = words.ToString();
    }

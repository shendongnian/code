    private void guess_Click(object sender, EventArgs e)
    {
        Button senderBtn = senderBtn as Button;
        if(senderBtn != null)
        {
            guess(senderBtn.Text);
        }
    }

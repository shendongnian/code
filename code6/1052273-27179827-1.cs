    private void PlayerInfoButton_Click(object sender, EventArgs e)
        {
            PlayerInfo playerinfoload = new PlayerInfo(this); //pass ref to self
            playerinfoload.Show();
        }

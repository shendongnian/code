    private void PlayerInfoButton_Click(object sender, EventArgs e)
    {
        PlayerInfo playerinfoload = new PlayerInfo();
        // Subscribe to the notification from PlayerInfo instance
        playerinfoload.PlayerConfirmed += PlayerHasBeenConfirmed;
        playerinfoload.Show();
    }
    // Method that receives the notification from PlayerInfo 
    private void PlayerHasBeenConfirmed()
    {
         P1NameLabel.Text = gm.P1Name;
         P1ClassLabel.Text = gm.P1Class;
         P2NameLabel.Text = gm.P2Name;
         P2ClassLabel.Text = gm.P2Class; 
    }

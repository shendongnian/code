    private void PlayerInfoButton_Click(object sender, EventArgs e)
    {
        PlayerInfo playerinfoload = new PlayerInfo();
        playerinfoload.PlayerConfirmed += PlayerHasBeenConfirmed;
        playerinfoload.Show();
    }
    // Method that receives the confirmation from PlayerInfo 
    private void PlayerHasBeenConfirmed()
    {
         P1NameLabel.Text = gm.P1Name;
         P1ClassLabel.Text = gm.P1Class;
         P2NameLabel.Text = gm.P2Name;
         P2ClassLabel.Text = gm.P2Class; 
    }

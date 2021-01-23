    private void Action_Click(object sender, RoutedEventArgs e)
    {
        if (blueTeamMap != null && redTeamMap != null)
        {
            GameWindow matchBlueTeam = new GameWindow(playersBlueTeam, playersRedTeam, blueTeamMap);
            matchBlueTeam.Closed += (s,e) => { 
                GameWindow matchRedTeam = new GameWindow(playersBlueTeam, playersRedTeam, redTeamMap);
                matchRedTeam.Show();
            };
            matchBlueTeam.Show();
            
        }
    }

    // In Form2
    public event Action<string> TeamInfoChanged;
    private void OnTeamInfoChanged()
    {
        var handler = TeamInfoChanged;
        if (handler != null) {
            handler(Team1Name.Text + " - " + team1score);
        }
    }
    private void Team1Name_TextChanged(object sender, EventArgs e)
    {
        OnTeamInfoChanged();
    }

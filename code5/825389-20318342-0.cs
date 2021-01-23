    private Team _CurrentTeam;
	public Team CurrentTeam
	{
		get { return this._CurrentTeam;}
		set {
			this.CurrentTeam = value;
			OnPropertyChanged("CurrentTeam");
			this.CurrentPlayers = this.Players.Where(player => player.Team == value);
		}
	}
	private IEnumerable<Player> _CurrentPlayers;
	public IEnumerable<Player> CurrentPlayers
	{
		get { return this.CurrentPlayers; }
		set
		{
			this.CurrentPlayers = value;
			OnPropertyChanged("CurrentPlayers");
		}
	}

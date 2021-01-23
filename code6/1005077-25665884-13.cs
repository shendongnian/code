	// class variable  
	public event EventHandler<BLevelSelectedEventArgs> BLevelSelected;
	// event handler
	public class BLevelSelectedEventArgs : EventArgs
	{
		public BLevelItem bLevel { get; set; }
		public BLevelSelectedEventArgs(BLevelItem bLevel) : base()
		{ 
			this.bLevel = bLevel;
		}
	}

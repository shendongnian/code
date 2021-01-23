	class StatRankedJoueur
	{
		private double modifyDate;
		public double ModifyDate
		{
			get { return modifyDate; }
			set { modifyDate = value; }
		}
		private int _summonerId;
		public int SummonerId
		{
			get { return _summonerId; }
			set { _summonerId = value; }
		}
		private Champion[] champions;
		public Champion[] Champions
		{
			get
			{
				return champions;
			}
			set
			{
				champions = value;
			}
		}
	}
	public class Champion
	{
		public int id { get; set; }
		public Stats stats { get; set; }
	}
	public class Stats
	{
		public int totalDeathsPerSession { get; set; }
		//etc
	}

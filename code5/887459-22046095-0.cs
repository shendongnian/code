	class Settings
	{
		public virtual string AppName
		{
			get { return "Base"; }
		}
		public virtual List<String> TabDetails()
			{
				List<String> TabDetails = new List<string>();
				helpTabDetails.Add("AAA");
				helpTabDetails.Add("BBB");
				return helpTabDetails;
			}
	} 
	class Demo : Settings
	{
		public override string AppName
		{
			get { return "XYX"; }
		}
	}

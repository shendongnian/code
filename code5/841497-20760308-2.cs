	public class ActivityMap : XTimeEntityTypeConfiguration<Activity>
	{
		public ActivityMap() : base() 
		{
			ConfigurationBehavior = new DefaultConfigurationBehavior(this);
		}
	}

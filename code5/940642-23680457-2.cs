	public class Dummy
	{
		public ConfigFileChangedHandler FileChangedHandler { get; set; }
		public void UseTheAction(ConfigFileChangedHandler action)
		{
			// invoke
			action(this, null);
			// or bind
			// object.Event += action;
		}
	}

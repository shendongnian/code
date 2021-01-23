	public interface IPlugin 
	{
		string Name { get; } 
		UserControl PluginControl { get; } //or a tab item 
	}
	//a sample dll would have 
	public class SamplePlugin : IPlugin 
	{
		public string Name { get { return "sample"; } } 
		public PluginControl 
		{
			get { 
				return AnInstanceOfControlHere; //create this somewhere 
			}
		}
	}

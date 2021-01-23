	public class NamesBuilder
	{
		private List<string> _names = new List<string>();
		public NamesBuilder AddName(string name)
		{
			_names.Add(name);
			return this;
		}
	}

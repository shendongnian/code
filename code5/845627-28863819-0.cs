	public class SingleAssemblyResolver : IAssembliesResolver
	{
		private readonly Assembly _ass;
		public SingleAssemblyResolver(Assembly ass) {
			_ass = ass;
		}
		public ICollection<Assembly> GetAssemblies() {
			return new[] { _ass };
		}
	}

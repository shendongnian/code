	/// <summary>
	/// Cheaty way to force Visual Studio to find all assembly references, even the ones not directly used by the main project.
	/// </summary>
	internal static class AssemblyReferences {
		internal static readonly Type t1 = typeof(Ninject.Web.Mvc.MvcModule);
	}

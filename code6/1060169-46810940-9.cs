	public class HomeController : Controller
	{
		public ActionResult HomeAction(Model model) { ... }
	}
	public class Model : IUrlSerializable
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Dictionary<string, string> GetQueryParams()
		{
			return new Dictionary<string, string>
			{
				[nameof(Id)] = Id,
				[nameof(Name)] = Name
			};
		}
	}

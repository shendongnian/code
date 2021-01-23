	public abstract class ExtendedController : Controller {
		protected MyDbContext Context {
			get { return RepositoryProxy.Context; }
		}
		protected override void OnActionExecuted(ActionExecutedContext filterContext) {
			RepositoryProxy.SaveIfContext();
			base.OnActionExecuted(filterContext);
		}
	}
	public class RepositoryProxy {
		private static HttpContext Ctx { get { return HttpContext.Current; } }
		private static Guid repoGuid = typeof(MyDbContext).GUID;
		public static MyDbContext Context {
			get {
				MyDbContext repo = Ctx.Items[repoGuid];
				if (repo == null) {
					repo = new MyDbContext();
					Ctx.Items[repoGuid] = result;
				}
				return repo;
			}
		}
		public static void SaveIfContext() {
			MyDbContext repo = Ctx.Items[repoGuid];
			if (repo != null) repo.SaveChanges();
		}
	}

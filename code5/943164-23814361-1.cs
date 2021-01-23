	public class MyUserManager : UserManager<User>
	{
		private readonly IMyUserStore _store;
		public MyUserManager(IMyUserStore store)
			: base(store)
		{
			_store = store;
		}
		public virtual Task<User> FindByKeyCodeAsync(string keyCode)
		{
			var a = new UserStore<User>();
			return _store.FindByKeyCodeAsync(keyCode);
		}
	}

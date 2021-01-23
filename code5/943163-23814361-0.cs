    public class MyUserStore : UserStore<User>, IMyUserStore
	{
		public Task<User> FindByKeyCodeAsync(string keyCode)
		{
			return Users.Where(x => x.KeCode == keyCode);
		}
	}

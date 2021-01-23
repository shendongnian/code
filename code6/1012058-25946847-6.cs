    public class AuthorizationProvider
	{
		public enum Abilities
		{
			View,
			Edit
		};
		private static IDictionary<string, object> _authorizations = new Dictionary<string, object>();
        // this method should be called at application bootstrap, such as Global.asax in an asp.net app
		public static void Configure()
		{
			_authorizations.Add(typeof(Teacher).Name + typeof(CourseReport).Name, new TeacherCanAccessCourseReportsQuery());
			_authorizations.Add(typeof(Teacher).Name + typeof(Order).Name, new TeacherCanAccessOrdersQuery());
            // other rules user type-entity type
		}
        // Can I view entity with primary key X?
		public static bool CanI<TEntity>(Abilities ability, object entityKey)
			where TEntity : IStoredEntity
		{
			TEntity entity = RepositoryProvider.Get<TEntity>().Load(entityKey);
			return CanI<TEntity>(ability, entity, AccountRoles.Admin);
		}
        // Can I view entity (and if I have a specific role, I surely can)?
		public static bool CanI<TEntity>(Abilities ability, TEntity entity, params string[] authorizedRoles)
			where TEntity : IStoredEntity
		{
			var principal = Thread.CurrentPrincipal as MyCustomPrincipal;
			if (authorizedRoles.Any(r => principal.IsInRole(r)))
				return true;
			var user = RepositoryProvider.Get<Account, AccountRepository>().GetUser(principal.AccountId);
            
            // my system has only two types of users
			if (user is Teacher)
			{
				return Can<Teacher, TEntity>(user as Teacher, ability, entity);
			}
			else if (user is TrainingCenter)
			{
				return Can<TrainingCenter, TEntity>(user as TrainingCenter, ability, entity);
			}
			return false;
		}
        /// Can user X (view|edit) entity Y?
        /// With some reflection I call the needed method. In this way I can add "abilities" to my ICanAccessQuery
        /// interface and its implementations without altering this class.
		public static bool Can<TAccount, TEntity>(TAccount user, Abilities ability, TEntity entity)
			where TAccount : IAccountOwner
			where TEntity : IStoredEntity
		{
			var key = typeof(TAccount).Name + typeof(TEntity).Name;
			if (_authorizations.ContainsKey(key))
			{
				var query = (ICanAccessQuery<TAccount, TEntity>)_authorizations[key];
				string methodName = "Can" + ability.ToString();
				var method = typeof(ICanAccessQuery<TAccount, TEntity>).GetMethod(methodName);
				return (bool)method.Invoke(query, new object[] { user, entity });
			}
			return false;
		}
	}
    

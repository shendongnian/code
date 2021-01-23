	public class ApplicationRoleManager : RoleManager<IdentityRole>
	{
		public ApplicationRoleManager(
			IRoleStore<IdentityRole> store,
			IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
			ILookupNormalizer keyNormalizer,
			IdentityErrorDescriber errors,
			ILogger<RoleManager<IdentityRole>> logger,
			IHttpContextAccessor contextAccessor)
			: base(store, roleValidators, keyNormalizer, errors, logger, contextAccessor)
		{
		}
	}

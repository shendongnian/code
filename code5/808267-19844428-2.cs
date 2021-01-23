	public class UserRepository
	{
		// ctor injects _dbContext and _tenantId
	
		public IQueryable<User> GetUsers()
		{ 
			var user = _dbContext.Users.Where(u => u.TenantId == _tenantId)
									   .Select(u => new User
									   {
										   Interests = u.Interests.Where(u => 
                                                         u.TenantId == _tenantId),
										   Other = u.Other,
									   };								
			}
		}
	}

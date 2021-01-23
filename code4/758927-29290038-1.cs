	protected void Application_Start() {
			MyProject.LinqToSQL.Repositories.SecurityRepository securityRepository = new MyProject.Repository.LinqToSQL.Repositories.SecurityRepository(connection);
			MyProject.Repository.HttpCache.Repositories.SecurityRepository securityCacheRepository = new MyProject.Repository.HttpCache.Repositories.SecurityRepository(securityRepository);
			MyProject.Domain.Service.Interface.SecurityService.Configure(securityCacheRepository);
	}

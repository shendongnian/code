    var school = RepositoryFactory.Create<ISchoolRepository>().Find(id);
    var userRepository = RepositoryFactory.Create<IUserRepository>();
    
    for (var i = school.Users.Count - 1; i >= 0; i--)
    {
         userRepository.Delete(school.Users[i]);
    }
    RepositoryFactory.Create<ISchoolRepository>().Delete(school);
    RepositoryFactory.Create<ISchoolRepository>().SaveChanges();

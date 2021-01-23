    var context = Substitute.For<MyCoolApplicationsEntities>();
    
    var applications = new List<Application>
    {
    	new Application {AppID = 1, ApplicationName = "MyCoolApplication"}
    };
    
    var mockApplications = Substitute.For<DbSet<Application>, IQueryable<Application>>();
    ((IQueryable<Application>)mockApplications).Provider.Returns(applications.AsQueryable().Provider);
    ((IQueryable<Application>)mockApplications).Expression.Returns(applications.AsQueryable().Expression);
    ((IQueryable<Application>)mockApplications).ElementType.Returns(applications.AsQueryable().ElementType);
    ((IQueryable<Application>)mockApplications).GetEnumerator().Returns(applications.AsQueryable().GetEnumerator());
    
    mockApplications.When(q => q.Add(Arg.Any<Application>()))
    	.Do(q => applications.Add(q.Arg<Application>()));
    
    mockApplications.When(q => q.Remove(Arg.Any<Application>()))
    	.Do(q => applications.Remove(q.Arg<Application>()));
    	
    context.Applications = mockApplications;

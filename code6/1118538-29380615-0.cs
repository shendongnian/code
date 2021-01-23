    var myData = new List<Team>(); //fill whatever test data you need
    
    var repo = new Mock<IRepositoryAsync<Team>>();
    repo.Setup(r=>r.Queryable()).Returns(myData.AsQueryable());
    var uow = new Mock<IUnitOfWorkAsync>();
    uow.Setup(u=>u.RepositoryAsync<Team>()).Returns(repo.Object);

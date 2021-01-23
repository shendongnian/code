    var mockQuery = new Mock<IRepositoryQuery<TEntity>>();
    
    // perform any setup needed on mockQuery for the particular System Under Test
   
    var mockRepository = new Mock<IRepository<TEntity>>();
    // perform any setup needed on mockRepository for the particular System Under Test
    // component that relies on query and repository
    // that is the System Under Test i.e. the focus of the unit test
    var systemUnderTest = new SystemUnderTest(mockRepository.Object, mockQuery.Object);

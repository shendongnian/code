    [TestMethod]
    [ExpectedException(typeof(System.AggregateException))]
    public async Task Service_GetDoc_ThrowsExceptionIfNull()
    {
        var nullRepository = new Mock<CCLDomainLogic.Repositories.DocRepository>();
        IDD emptyDoc = null;
    
        nullRepository
            .Setup<Task<CCLDomainLogic.DomainModels.Doc>>(x => x.GetDocAsync(It.IsAny<int>()))
            .Returns(() => Task<CCLDomainLogic.DomainModels.Doc>.Factory.StartNew(() => emptyDoc));
    
        DocService s = new DocService(nullRepository.Object);
    
        var foo = await s.GetDocAsync(1).Result;
    }  
    

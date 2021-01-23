    [Test, ExpectedException(typeof(ArgumentNullException), ExpectedMessage = @"Value cannot be null.
    Parameter name: entity")]
    public void To_Add_DocumentStatusIsNull_ThrowsInvalidOperationException_ServiceTest()
    {
        _IDocumentStatusRepositoryMock = new Mock<IDocumentStatusRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        DocumentStatusService documentStatusService = new  
         DocumentStatusService(_unitOfWorkMock.Object,  
          _IDocumentStatusRepositoryMock.Object); 
        DocumentStatus documentStatus;
        documentStatus = null;
        _IDocumentStatusRepositoryMock.Setup(m => m.Add(documentStatus));
        documentStatusService.Add(documentStatus);
    }
...
    public virtual void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        _repository.Add(entity);
    }

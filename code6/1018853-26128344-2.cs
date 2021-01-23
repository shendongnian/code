    [Test]
    public void PassingANullEntityToAddMustThrowArgumentNullException()
    {
        var documentStatusService = new  DocumentStatusService(...); 
        Assert.Throws<ArgumentNullException>(() =>  documentStatusService.Add(null));
    }

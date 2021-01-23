    try 
    {
        _IDocumentStatusRepositoryMock.Setup(m => m.Add(documentStatus));
        documentStatusService.Add(documentStatus);
    }
    catch (Exception )
    {
        Assert.Fail(); // or nothing is expected behaviour
    }

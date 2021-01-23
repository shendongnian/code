    [Test]
    public void ShouldSucessfullySaveNewDepartment()
    {
        var department = CreateDepartment();
        mockRepository.Setup(r => r.Add(department));
        var result = sut.SaveDepartment(department);
        Assert.True(result);
        mockRepository.VerifyAll();
        mockUnitOfWork.Verify(u => u.Save());
    }

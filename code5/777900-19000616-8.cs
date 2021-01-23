    [Test]
    public void ShouldNotSaveExistingDepartment()
    {
        mockUnitOfWork.Setup(u => u.Save()).Throws<NonUniqueEntityException>();
        var result = sut.SaveDepartment(CreateDepartment());
        Assert.False(result);
        mockUnitOfWork.VerifyAll();
    }

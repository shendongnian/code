    [Test]
    public void ShouldGetAllDepartments()
    {
        var expected = new List<Department>{ CreateDepartment(), CreateDepartment()};
        mockRepository.Setup(r => r.GetAll()).Returns(expected);
        var actual = sut.GetAllDepartments();
        Assert.That(actual, Is.EqualTo(expected));
        mockRepository.VerifyAll();
    }

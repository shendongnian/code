    using (var mock = AutoMock.GetStrict())
    {
        var subjectRepositoryMock = new Mock<ISubjectRepository>();
        subjectRepositoryMock.Setup(x => x.GetSubjects(1)).Returns(...);
        mock.Provide(subjectRepositoryMock.Object);
        var component = mock.Create<StudentService>();
        int rank = component.GetRank(1);
        // verify is not needed once again
        Assert.AreEqual(1, rank, "GetRank method fails");
    }

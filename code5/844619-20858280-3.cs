    [Test]
    public void Should_Update_Person_When_Name_Is_Correct()
    {
        // Arrange
        var p = new Person(); // person is a real class
        var timeProviderMock = new Mock<ITimeProvider>();
        var time = DateTime.Now;
        timeProviderMock.Setup(tp => tp.GetCurrentTime()).Returns(time);
        Services.TimeProvider = timeProviderMock.Object;
        // Act 
        Services.UpdatePerson(p, "John", "Lennon");
        // Assert
        p.FirstName.Should().Be("John");
        p.LastName.Should().Be("Lennon");
        p.ModifiedDate.Should().Be(time); // verify that correct date was set
        timeProviderMock.VerifyAll();
    }

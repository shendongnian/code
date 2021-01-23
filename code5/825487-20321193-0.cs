    var otherMocker = new AutoMoqer();
    Mocker.GetMock<IService>.Setup(s => s.Do()).Returns(1);
    otherMocker.GetMock<IService>.Setup(s => s.Do()).Returns(1);
    var c1 = Mocker.Resolve<TestableClass>();
    var c2 = otherMocker.Resolve<TestableClass>();
    Assert.That(c1, Is.Not.SameAs(c2)); // true
    Assert.That(c1.service, Is.NotSameAs(c2.service)) // true

    var parameters = new List<ParameterType>();
    processor.Setup(x => x.Execute(It.IsAny<ParameterType>()))
        .Callback(param => parameters.Add(param));
    CallCodeUnderTest(processor.Object);
    Assert.That(parameters, Is.EqualTo(new[] { expected1, expected2, expected3 }));

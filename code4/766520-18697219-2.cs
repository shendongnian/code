    var specs = new List<ServiceSpecification>
    {
        ServiceSpecification.Parse("In8bytesOut16bytes"),
        ServiceSpecification.Parse("In8wordsOut4words"),
        ServiceSpecification.Parse("In8bytes")
    };
    foreach(var spec in specs)
        Console.WriteLine(spec.IsSatisfiedBy(service));

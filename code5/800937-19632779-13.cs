    var spec1 = SpecificationParser.Parse("10, 12, 14, 16");
    spec1.IsSatisfiedBy(11); // false
    var spec2 = SpecificationParser.Parse("[10-20];21;23,25");
    spec2.IsSatisfiedBy(9); // false
    spec2.IsSatisfiedBy(19); // true
    spec2.IsSatisfiedBy(22); // false

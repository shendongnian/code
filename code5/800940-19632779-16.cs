    var rangeSpec = new RangeSpecification(10, 15);
    var is13inRange = rangeSpec.IsSatisfiedBy(13); // true
    var is20inRange = rangeSpec.IsSatisfiedBy(20); // false
    var inSpec = new InSpecification(1,2,5,8);
    var is13inList = inSpec.IsSatisfiedBy(13); // false

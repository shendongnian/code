    var spec = new UserSpecification();
    // then pass your user to check if he satisfies specification
    if (spec.IsSatisfiedBy(obj))
        // do something
    // or filter users with specification
    var validUsers = users.Where(spec.IsSatisfiedBy);

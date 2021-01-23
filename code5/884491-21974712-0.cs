    DateTime dt = // coming from your input
    if (tzEastern.IsInvalidTime(dt))
    {
       // Throw an exception to tell your user that the input is invalid.
    }
    else if (tzEastern.IsAmbiguousTime(dt))
    {
       // Throw an exception to ask your user to pick from either EST (-5) or EDT (-4).
       // Use their choice of offset as a new input parameter.
    }
    DateTimeOffset dateToTest = new DateTimeOffset(dt, tzEastern.GetUtcOffset(dt));

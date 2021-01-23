    // thatObject.Color == ColorEnum.Red
    // or
    // thatObject.Color == "Red"
    if (GetKnowColor(thatObject.Color) == KnownColorEnum.Red) // true
    { }
    // thatObject.Color == ColorEnum.Blue
    if (GetKnowColor(thatObject.Color) == KnownColorEnum.Red) // false
    { }

    // instead of this
    if ((bool)row[column]) { ... }
    // do this
    DateTime dateAndTimeOfClick = (DateTime)row[other_column];
    bool isStillTrue = DateTime.UtcNow - dateAndTimeOfClick < TimeSpan.FromDays(1);
    if (isStillTrue) { ... }

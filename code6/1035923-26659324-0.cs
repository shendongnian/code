        var pattern = InstantPattern.GeneralPattern;
        var strings = instants.Select(pattern.Format);
    or
        var pattern = LocalDateTimePattern.GeneralIsoPattern;
        var strings = ldts.Select(pattern.Format);

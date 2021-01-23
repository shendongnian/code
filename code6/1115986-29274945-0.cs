    // TODO: Extract an IClock interface that has a SystemClock
    // implementation and a FakeClock implementation - then you
    // can write lots of unit tests for this.
    DateTime utcNow = DateTime.UtcNow;
    TimeZoneInfo zone = ...; // South Africa (parameter?)
    TimeSpan publishTimeOfDay = ...; // 8pm (parameter?)
    DateTime localNow = TimeZoneInfo.ConvertTime(utcNow, zone);
    DateTime publishDate = localNow.TimeOfDay >= postTimeOfDay
        ? localNow.Date : localNow.Date.AddDays(-1);
    DateTime localPublishDateTime = publishDate + publishTimeOfDay;
    return TimeZoneInfo.ConvertTimeToUtc(localPublishDateTime, zone);

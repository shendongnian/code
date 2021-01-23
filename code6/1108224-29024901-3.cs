    DateTime dt = (DateTime) yourSqlDataReader["TransactionDate"];
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    if (tz.IsAmbiguousTime(dt))
    {
        // record this item in some way, so you can review it manually later
    }
    else
    {
        DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dt, tz);
        // save this field to a new table or a new column in the current table
    }

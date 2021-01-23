    var query = from x in db.DoubleDataValueArchive select x;
    query = query.Where(x => x.DataPointId != null);
    // Check if only errors should be shown (that are listed in errorDps)
    List<int> errorDps = new List<int>();
    if (errorsOnly.HasValue) {
        if (errorsOnly == true)
        {
            errorDps = db.DataPoints.Where(x => x.DataType == 4).Select(x => x.Id).ToList();
            query = query.Where(x => errorDps.Contains((int)x.DataPointId));
        }
    }
    // Start Date
    if (startDate.HasValue) {
        startDate = startDate.Value.ToUniversalTime();
        query = query.Where(x => x.DateValue >= startDate);
    }
    // End Date
    if (endDate.HasValue)
    {
        endDate = endDate.Value.ToUniversalTime();
        query = query.Where(x => x.DateValue <= endDate);
    }

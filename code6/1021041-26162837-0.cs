    string keyword = "2014";
    DateTime parsedDate;
    if (DateTime.TryParseExact(keyword, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
    {
        // only year provided
        //Compare only year part
        unitOfWork.StammdatenRepository.Get()
                   .Where(s => (s.MyDate.HasValue
                          && s.MyDate.Value.Year == parsedDate.Year));
    }
    else if (DateTime.TryParseExact(keyword, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
    {
        //Complete date provided
        //compare complete date
        unitOfWork.StammdatenRepository.Get()
                    .Where(s => (s.MyDate.HasValue
                              && s.MyDate.Value.Date == parsedDate.Date));
    }
    else
    {
        //invalid keyword
    }

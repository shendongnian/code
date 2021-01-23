    var updateDateString = "2010-06-11";
    DateTime updateDate;
    
    if (DateTime.TryParse(updateDateString, out updateDate))
    {
        _adRepository.Query.Where(p => p.DateModified <= updateDate).FirstOrDefault();
    }
    else
    {
         // throw an exception or something
    }

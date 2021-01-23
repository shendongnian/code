    string Update_old = "07.02.2014 13:30:36";
    string Rate_s = "5";
    DateTime oldDt = DateTime.ParseExact(Update_old, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    string Update_New = "07.02.2014 13:30:46";
    DateTime newDt = DateTime.ParseExact(Update_New, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    TimeSpan seconds = TimeSpan.FromSeconds(int.Parse(Rate_s));
    if (oldDt + seconds > newDt)
    {
        // ...
    }

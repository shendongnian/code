    Regex rgxStreet = new Regex(config.StreetReg);
    Regex rgxNumber = new Regex(config.NumberReg);
    Regex rgxCity = new Regex(config.CityReg);
    Regex rgxZIP = new Regex(config.ZipReg");
    foreach (var line = File.ReadLines(fileName, Encoding.GetEncoding(65001))
                            .Select(l => l.TrimEnd(';').Trim())
    {
        if(config.CityNum == i && rgxCity.IsMatch(line))
            a.City = line;
        ...
        i++;
    }
    return a;

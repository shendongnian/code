    // set the correct culture infos, here from the Netherlands and Spain. Use your cultures ;-)
    System.Globalization.CultureInfo sourceCultureInfo =
        new System.Globalization.CultureInfo("nl-NL");
    System.Globalization.CultureInfo targetCultureInfo =
        new System.Globalization.CultureInfo("es-ES");
    // convert
    DateTime sourceDate = DateTime.ParseExact(
        str.ToString(), "dd.MM.yyyy HH:mm:ss", sourceCultureInfo);
    string targetDate = sourceDate.ToString(targetCultureInfo)

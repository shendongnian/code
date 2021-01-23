    StringBuilder lineTotal = new StringBuilder();
    while ((line = unitsOfMeasurement.ReadLine()) != null)
    {
        lineTotal.Append(line + Environment.NewLine);
    }
    
    fileLines =  lineTotal.ToString().Split(new string[]{Environment.NewLine},
                                      StringSplitOptions.RemoveEmptyEntries);

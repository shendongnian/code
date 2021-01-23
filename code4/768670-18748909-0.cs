    string reportnames = lstbxReports.SelectedValue.ToString();
    
    var firstReport = reportnames.First(); // No error checking here, would use FirstOrDefault with null checks.
    
    if (firstReport == "OverView")
       PrintOverview(filename);
    else
       PrintSource(filename);
    
    // Now print out the rest
    reportnames.Skip(1)
               .ToList()
               .ForEach(rp =>
    {
       if (rp == "OverView")
          PrintOverviewAppend(filename);
       else
          PrintSourceAppend(filename);
    });

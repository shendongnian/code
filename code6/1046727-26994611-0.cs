    string filename = @"c:\temp\test.txt";
    string usDateString = "11/18/2014 12:32"; // MM/dd/yyyy
    string ukDateString = "18/11/2014 12:33"; // dd/MM/yyyy
    //I'm mimicking you getting the DateTime from the user here    
    //I'm assuming when you receive the date(s) from the front
    //end you'll know the culture - if not then all bets are off. 
    DateTime usDate = 
          DateTime.Parse(usDateString, CultureInfo.GetCultureInfo("en-US"));
    DateTime ukDate = 
          DateTime.Parse(ukDateString, CultureInfo.GetCultureInfo("en-GB"));
    //write the dates to a file using the "o" specifier
    File.AppendAllText(filename, usDate.ToString("o") + Environment.NewLine);
    File.AppendAllText(filename, ukDate.ToString("o") + Environment.NewLine);
    //read them back in as strings
    string[] contents = File.ReadAllLines(filename);
            
    foreach (var date in contents)
    {
        //prove we can parse them as dates.
        Console.WriteLine(DateTime.Parse(date).ToString());
    }

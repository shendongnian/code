    List<string> fNames = new List<string>() {"Aleisha", "Sadye", "Ethyl"};
    List<string> lNames = new List<string>() {"Smith", "Johnson", "Melody"};
    Random r = new Random();
    int wFName = r.Next(0, fNames.Count);
    int wLName = r.Next(0, lNames.Count);
    System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\names.txt", fNames[wFName] + lNames[wLName]);
    fNames.Remove(wFName);
    lNames.Remove(lFName);

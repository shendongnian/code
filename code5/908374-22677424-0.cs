    var dictionary = new Dictionary<char, string>();
    
    dictionary.Add('A', "Alpha");
    // and so on..
    
    public static string ParseTaxiway(string taxiway)
    {
     string finalValue = "";
    
     foreach (var character in taxiway)
     {
      finalValue += dictionary[character] +" ";
     }
    
     return finalValue;
    }

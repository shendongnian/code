    Regex r = new Regex("^((1[0-4]|[0-9])?\\.(25|5|75)0*|15\\.(25|5)0*)$");
    string[] arr = {".25", "17.545", "3.75000","19.5","10.500","0.25"};
    
    foreach(string s in arr) {
        if (r.IsMatch(s)) { Console.WriteLine(s); }
    }

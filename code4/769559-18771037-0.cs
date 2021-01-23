    string name = GetName(); // returned string could be empty
    string messageAddition = "";
    if (string.IsNullOrWhiteSpace(name)) {
        messageAddition = " (Name is: " + name + ")";
    }
      
    foreach(string s in GetListOfStrings()) {       
        Console.WriteLine(s + messageAddition);
    }

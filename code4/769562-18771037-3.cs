    string name = GetName(); // returned string could be empty
    foreach(string s in GetListOfStrings()) {       
        string messageAddition = "";
        if (string.IsNullOrWhiteSpace(name)) {
            messageAddition = " (Name is: " + name + ")";
        }
        Console.WriteLine(s + messageAddition);
        // more code which uses the computed value.. 
        // otherwise the condition can be moved out the loop
    }

    string name = GetName(); // returned string could be empty
    bool nameIsEmpty = string.IsNullOrWhiteSpace(name);
    foreach (string s in GetListOfStrings()) {       
        string messageAddition = "";
        if (!nameIsEmpty) {
            messageAddition = " (Name is: " + name + ")";
        }
        Console.WriteLine(s + messageAddition);
        // more code which uses the computed value.. 
        // otherwise the condition can be moved out the loop
    }

        //Create lists of strings
        var a = new List<string> { "A", "B" };
        var b = new List<string> { "C", "D" };
        var c = new List<string> { "E", "F" };
        //Create a list containing all the lists
        var abc = new List<List<string>> { a, b, c };
        //Get the values
        var strings = abc.
            SelectMany(o => o).
            ToList();

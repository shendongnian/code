    var split = source.Split(placeholder); // create array of items without placeholders
    var result = split[0]; // copy first item
    for(int i = 1; i < result.Length; i++)
    {
        bool replace = ... // ask user
        result += replace ? replacement : placeholder; // to put replacement or not to put
        result += split[i]; // copy next item
    }

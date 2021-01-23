    // original input
    string line = "13,G,true";
    //  splitting the string based on a character. this gives us
    // ["13", "G", "true"]
    string[] split = line.Split(',');
    // now we parse them based on their type
    int a = int.Parse(split[0]);
    char b = split[1][0];
    string c = split[2];

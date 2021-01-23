    object obj = "Int32";
    string str1 = "Int32";
    string str2 = typeof(int).Name;
    Console.WriteLine(obj == str1); // true
    Console.WriteLine(str1 == str2); // true
    Console.WriteLine(obj == str2); // false !?

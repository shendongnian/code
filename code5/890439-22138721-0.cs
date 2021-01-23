    object obj = "";
    string str1 = "";
    string str2 = String.Empty;
    Console.WriteLine(obj == str1); // true
    Console.WriteLine(str1 == str2); // true
    Console.WriteLine(obj == str2); // sometimes true, sometimes false?!

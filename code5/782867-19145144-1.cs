    string s = "a      b c d   e f g h      \t\t i";
    var test = Regex.Split(s, @"\s{2,}");
    Console.WriteLine(test[0]);
    Console.WriteLine(test[1]);
    Console.WriteLine(test[2]);
    Console.WriteLine(test[3]);

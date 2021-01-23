    string s = "a  b c d  e f g h  i";
    var test = s.Split(new String[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
    
    Console.WriteLine(test[0]); // a
    Console.WriteLine(test[1]); // b c d
    Console.WriteLine(test[2]); // e f g h
    Console.WriteLine(test[3]); // i

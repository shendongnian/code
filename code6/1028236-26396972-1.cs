    String s1 = "1 ";
    String s2 = "2 ";
    String stmp = s1;
    s1 += s2;
    s2 = stmp;
    Console.WriteLine(s1);  //  1 2
    Console.WriteLine(s2);  //  1

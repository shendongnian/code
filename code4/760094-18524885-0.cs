    string a1 = "a";
    string a2 = "a";
    string aa1 = a1 + a2;
    string aa2 = a1 + a2;
    object o1 = a1;
    object o2 = a2;
    object o3 = aa1;
    object o4 = aa2;
    Console.WriteLine(a1 == a2);   // True
    Console.WriteLine(aa1 == aa2); // True
    Console.WriteLine(o1 == o2);   // True
    Console.WriteLine(o3 == o4);   // False

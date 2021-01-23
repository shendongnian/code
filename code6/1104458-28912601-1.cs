    List<string> strs = new List<string>();
    strs.Add("AAA");
    strs.Add("BBB");
    strs.Add("CCC");
    strs.RemoveAt(1); // remove "BBB"
    Console.WriteLine(strs[0]); // yields AAA
    Console.WriteLine(strs[1]); // yields CCC

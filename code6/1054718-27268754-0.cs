    s = Console.ReadLine();
    //User inputs "First Second Third"
    string[] ssize = s.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
    foreach(string str in ssize)
       Console.WriteLine("string: {0}", str);

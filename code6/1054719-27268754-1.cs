    s = Console.ReadLine();
    //User inputs "First Second Third"
    string[] ssize = s.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
    for(int i = 0; i < ssize .Length; i++)
       Console.WriteLine("string {0}: {1}", i+1, ssize [i]);

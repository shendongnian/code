    string s = "10:00 AM";
    var array = s.Split(new string[] {":", " "}, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine(array[0]); //10
    Console.WriteLine(array[1]); //00
    Console.WriteLine(array[2]); //AM

    string s = "aa bb cc dd ee ff gg hh ii kk";
    var array = s.Split( new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
    string newstring = "";
    for (int i = 0; i < 5; i++)
         newstring += array[i] + " ";
    Console.WriteLine(newstring.Trim());

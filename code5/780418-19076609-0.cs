    string s = "ahde7394";
    int index = 0;
    foreach (var i in s)
    {
         if(Char.IsDigit(i))
         {
            index = s.IndexOf(i);
            break;
         }
    }
    Console.WriteLine(s.Substring(0, index));
    Console.WriteLine(s.Substring(index));

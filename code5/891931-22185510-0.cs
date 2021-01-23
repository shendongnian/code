    var text = 
      "somet interesting text\n" +
      "some text that should be in the same line\r\n" +
      "some text should be in another line";
    
    string[] stringSeparators = new string[] { "\r\n" };
    string[] lines = text.Split(stringSeparators, StringSplitOptions.None);
    Console.WriteLine("Nr. Of items in list: " + lines.Length); // 2 lines
    foreach (string s in lines)
    {
       Console.WriteLine(s); //But will print 3 lines in total.
    }

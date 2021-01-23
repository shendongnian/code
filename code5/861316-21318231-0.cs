    [TestMethod()] 
    public void TestMethod1()
    {
        var myText = "123456 1234567, 123458, 00123456, 01234567";
        var regex = New Regex("( |,)*(\d+)");
        var m = regex.Match(myText);
        var matchcount = 0
        while (m.Success) 
      {
         Console.WriteLine("Match"+ (++matchCount));
         for (int i = 1; i <= 2; i++) 
         {
            Group g = m.Groups[i];
            Console.WriteLine("Group"+i+"='" + g + "'");
            CaptureCollection cc = g.Captures;
            for (int j = 0; j < cc.Count; j++) 
            {
               Capture c = cc[j];
               System.Console.WriteLine("Capture"+j+"='" + c + "', Position="+c.Index);
            }
         }
         m = m.NextMatch();
      }
    }

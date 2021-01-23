    using System;
					
    public class Program
    {
      public static void Main()
      {
        string s1=@"[q:6][ilvl:70](randomword)";
		
        var tmp = s1.Split(new string [] {":","]" }, StringSplitOptions.None);
		
        string res1 = tmp[1];
        string res2 = tmp[3];
		
        string res3 = s1.Split(new string [] {"](",")" }, StringSplitOptions.None)[1];
		
        Console.WriteLine("1 -> "+res1);
        Console.WriteLine("2 -> "+res2);
        Console.WriteLine("3 -> "+res3);
      }
    }

      using System;
      using System.Text.RegularExpressions;
      public class Test
        {
        public static void Main()
        {
         String input = @"[[Parent1 [[Child 1]],[[Child 2]],[[Child 3]]]] [[Parent2 [[Child 1]],[[Child 2]]]]";
         Regex rgx = new Regex(@"(?<parent>Parent\d )|(?!^)\G(?:\[\[(?<child>.*?)]]),?");
         foreach (Match m in rgx.Matches(input))
        {
        Console.WriteLine(m.Groups["parent"].Value);
        Console.WriteLine(m.Groups["child"].Value);
        }
        }
        }

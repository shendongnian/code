     dynamic script = CSScript.Evaluator
                             .LoadCode(@"using System;
                                         public class Script
                                         {
                                             public int Sum(int a, int b)
                                             {
                                                 return a+b;
                                             }
                                         }");
    int result = script.Sum(1, 2);

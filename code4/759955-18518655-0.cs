    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    internal class Program
    {
    private static void Main(string[] args)
    {
        var array =
            "{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,} , {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,}";
        string input = array;
        string pattern = @"{|}";
        var index = 0;
        var results = new int[100,100];
        foreach (var result in Regex.Split(input, pattern))
        {
            var sp = result.Split(',');
            if (sp.Length <4)
            continue;
            for (int i = 0; i < sp.Count(); i++)
            {
                if (!string.IsNullOrEmpty(sp[i]))
                 results[index,i] = Convert.ToInt32(sp[i]);
            }
            index++;
        }
       }
      }
     }

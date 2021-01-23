    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            var MyRegex = new Regex(@"(?i)<span class=([""']).+?\1 title=([""']).+?\2>", RegexOptions.CultureInvariant | RegexOptions.Compiled);
            var str = @"<p><span class=""others"" title=""This is 'an elderly pilgrim' speaking""><span class=""others"" title=""This is 'an elderly pilgrim' speaking""><span class=""others"" title=""This is 'an elderly pilgrim' speaking""><span class=""others"" title=""This is 'an elderly pilgrim' speaking""><span class=""higbie"" title=""This is Calvin Higbie speaking""><span class=""ballou"" title=""This is Mr. Ballou speaking""><span class=""ballou"" title=""This is Mr. Ballou speaking""><span class=""higbie"" title=""This is Calvin Higbie speaking""></p>";
      //      var distinct_values = MyRegex.Matches(str).
    //                    Cast<Match>().Select(p => p.Value).Distinct().ToList();
            var new_arr = new List<string>();
            var matches = MyRegex.Matches(str);
            for (int i=0; i<matches.Count; i++)
                if (!new_arr.Contains(matches[i].Value))
                   new_arr.Add(matches[i].Value);
                   
            Console.WriteLine(string.Join("\n", new_arr));
        }
    }

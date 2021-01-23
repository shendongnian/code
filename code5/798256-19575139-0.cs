    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    namespace BatchRegex
    {
        class Program
       {
          static void Main(string[] args)
        {
            string[] target = 
	    {
              
                "<div>/*...*/</div> <div>/*...*/<br></div> <div>/*...*/<br></div>",
	            "/*...*/<br></div> or /*...*/<br/></div>"
	
	    };
            foreach (var tgt in target)
            {
               var rx1 = new Regex[]{new Regex(@"<div>/\*(.(?!\*/))*\*/(</div>|<br/></div>|<br></div>)", RegexOptions.Multiline),
			    new Regex(@"/\*[^>]+?\*/(<br/>|<br>)", RegexOptions.Multiline),
	            new Regex(@"/\*[^>]+?\*/", RegexOptions.Multiline)};
                foreach (var rgx in rx1)
                {
                    var rgxMatches = rgx.Matches(tgt).Cast<Match>();
                    Parallel.ForEach(rgxMatches, match =>
                        {
                            Console.WriteLine("Found {0} in target {1}.", match, tgt);
                        });
                }
            }
            
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

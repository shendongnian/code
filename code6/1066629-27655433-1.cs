    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        using System;
        using System.Text.RegularExpressions;
    
        class Program
        {
            static void Main()
            {
                string pat = @"\d{4}-\d{2}-\d{2}\:";
    
                // Instantiate the regular expression object.
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
    
    
                String line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\PATH\Filename.txt");
                while ((line = file.ReadLine()) != null)
                {
                                   Match m = r.Match(line);
                if (m.Success)
                {
                    // A date is found ; make new List/some data structure to extract data on this date
                    Console.WriteLine("Date : {0}",m.Value);
                }
                else
                {
                    Console.WriteLine("\tVales {0} ",line);
                }
                }
    
                Console.ReadKey();
            }
        }
    }

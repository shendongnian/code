    namespace StringSearch
    {
        using System.Text.RegularExpressions;
    
        class TestRegularExpressionValidation
        {
            static void Main()
            {
                string[] numbers = 
    {
        "123-555-0190", 
        "444-234-22450", 
        "690-555-0178", 
        "146-893-232",
        "146-555-0122",
        "4007-555-0111", 
        "407-55-0111",
        "a1b-Cd-EfgH",
        "a1b-Cd-Efgn",
        "UM2345678",
        "11/12/2013 4:10:06 PM              UM2345678                   UM2345678",
        "407-2-5555", 
    };
                string sPattern = "[A-Za-z]{2}[0-9]{4}";
    
    
                foreach (string s in numbers)
                {
                    System.Console.Write("{0,14}", s);
                    MatchCollection matches = Regex.Matches(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    foreach (var match in matches)
                    {
                        System.Console.WriteLine("{0} - valid", match.ToString());
                    }
                }
    
                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
    }

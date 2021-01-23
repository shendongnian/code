    using System;
    using System.Text.RegularExpressions;
    class TestRegularExpressionValidation
    {
        static void Main()
        {
            string[] listofinputs = 
            {
                "CRM32323324", 
                "232dsf12414", 
                "adfn adfm srf333333333 sdj",
                "srf333333333",
                "saca dfd444444444r.",
                "CRM876969697", 
            };
            string sPattern = "^\\w{3}\\d{9}$";
            foreach (string s in listofinputs)
            {
                System.Console.Write("{0,14}", s);
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    System.Console.WriteLine(" - valid");
                }
                else
                {
                    System.Console.WriteLine(" - invalid");
                }
            }
    
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }

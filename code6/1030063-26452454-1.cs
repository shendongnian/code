    string s, revs = "";
            Console.WriteLine("Please Enter Word");
            s = Console.ReadLine();
            string r = Regex.Replace(s , @"(\s|-)", "");
    
            for (int i = r.Length-1; i >= 0; i--)
            {
                revs += r[i].ToString();
            }
    
            if (revs == r)
            {
                Console.WriteLine("Entered string is palindrome \n String was {0} and reverse string was {1}", s, revs);
            }
            else
            {
                Console.WriteLine("String entered was not palindrome.");
            }
            Console.ReadKey();

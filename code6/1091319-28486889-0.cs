            var orginal = "\"31882757623\"<sip:+31882757623@asklync.nl;user=phone>;epid=5440626C04;tag=daa784a738";
            string second = "vandrielfinance.nl";
            var returnValue = string.Empty;
            var split = orginal.Split('@');
            if (split.Length > 0)
            {
                var findFirstSemi = split[1].IndexOf(";");
                var restOfString = split[1].Substring(findFirstSemi, split[1].Length - findFirstSemi);
                returnValue = split[0] + "@" + second + restOfString;
            }
            
            Console.WriteLine("Original String:");
            Console.WriteLine("{0}", orginal);
            Console.WriteLine("Replacement String:");
            Console.WriteLine("{0}", returnValue);
            //return returnValue;

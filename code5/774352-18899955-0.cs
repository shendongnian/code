            foreach (string s in list)
            {
                var rgx = new Regex("[^0-9]");
                // Remove all characters other than digits
                s=rgx.Replace(s,"");
                // Can we reduce this to just one IsMatch() call???
                if (s.Contains("1312") && CheckMatch(s))
                {
                    Console.WriteLine("'{0}' is a match for '1312'", s);
                }
                else
                {
                    Console.WriteLine("'{0}' is NOT a match for '1312'", s);
                }
            }
           private static bool CheckMatch(string s)
           {
                var index = s.IndexOf("1312");
                // Check if no. of characters to the left of '1312' is same as no. of characters to its right
                if(index == s.SubString(index).Length()-4)
                   return true;
                return false;
           }

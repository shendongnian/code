    class Program
    {
        static string InsertSeparators(string s)
        {
            string decSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    
            int separatorPos = s.IndexOf(decSeparator);
            if (separatorPos >= 0)
            {
                string decPart = s.Substring(separatorPos + decSeparator.Length);
                // split the string into parts of 3 or less characters
                List<String> parts = new List<String>();
                for (int i = 0; i < decPart.Length; i += 3)
                {
                    string part = "";
                    for (int j = 0; (j < 3) && (i + j < decPart.Length); j++)
                    {
                        part += decPart[i + j];
                    }
                    parts.Add(part);
                }
                string groupSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
                s = s.Substring(0, separatorPos) + decSeparator + String.Join(groupSeparator, parts);
            }
    
            return s;
    
        }
    
        static void Main(string[] args)
        {
    
            for (int n = 0; n < 15; n++)
            {
                string s = Math.PI.ToString("0." + new string('#', n));
                Console.WriteLine(InsertSeparators(s));
            }
    
            Console.ReadLine();
    
        }
    }
    

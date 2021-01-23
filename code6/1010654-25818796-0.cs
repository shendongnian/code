        public static bool IsMatch(string pattern, string line)
        {
            var patternSplit = pattern.Split(',');
            if (!line.StartsWith(patternSplit[0])) return false;
            if(patternSplit.Count() > 2){
               for (var i = 1; i < patternSplit.Count() - 1; i++)
               {
                   if (!line.Contains(patternSplit[i])) return false;
               }
            }
            if (!line.EndsWith(patternSplit[patternSplit.Count() - 1])) return false;
            return true;
        }
   
    static void Main(string[] args)
            {
                var matchingData = "quick brown fox jumped over a lazy dog";
                var failingData = "I am batman";
                var pattern = "qu,pe,ov,og";
                if(IsMatch(pattern, matchingData))Console.WriteLine("{0} matches pattern {1}", pattern, matchingData);
                if(!IsMatch(pattern, failingData)) Console.WriteLine("{0} does not match {1}", pattern, failingData);
                Console.ReadKey();
            }

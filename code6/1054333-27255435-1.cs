    class Program
    {
        static void Main(string[] args)
        {
            string val1 = "Have a good day";
            string val2 = "Have a very good day, Joe";
    
            MatchCollection words1 = Regex.Matches(val1, @"\b(\w+)\b");
            MatchCollection words2 = Regex.Matches(val2, @"\b(\w+)\b");
    
            var hs1 = new HashSet<string>(words1.Cast<Match>().Select(m => m.Value));
            var hs2 = new HashSet<string>(words2.Cast<Match>().Select(m => m.Value));
            // Optionaly you can use a custom comparer for the words.
            // var hs2 = new HashSet<string>(words2.Cast<Match>().Select(m => m.Value), new MyComparer());
    
            // h2 contains after this operation only 'very' and 'Joe'
            hs2.ExceptWith(hs1); 
    
        }
    }

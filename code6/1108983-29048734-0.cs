      Regex rx = new Regex(@"Customer rating (?<rating>\d\.\d)\/5\.0"); // <= Updated and cleaned regex
    
      MatchCollection matches = rx.Matches("(X=Customer rating 1.0/5.0)");
    
       if (matches.Count > 0)
       {
            Console.WriteLine("Matched :" );
    
            // Get the match output 
            foreach (Match item in matches)
            {
                 Console.WriteLine(item.Value);
            }
       }

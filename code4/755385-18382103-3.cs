    public static void Main()
    { 
      // Leaves room for ambiguity if the random prefix or index suffix look 
      // like dates as well.
      var pattern = "((0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])((19|20)[0-9]{2}))";
      
      // Or, I see in your comment that the dates are from the current month. 
      // If so then this decreases the probability of a false match. You could
      // use the following pattern instead:
      var year =  DateTime.Today.Year;
      var month  = string.Format("{0:00}", DateTime.Today.Month);
      pattern = "((0[1-9]|[12][0-9]|3[01])(" + month + ")(" + year + "))";		  
      
      var str = "D1011608201313";
      var matches = Regex.Matches(str, pattern);
      if (matches.Count == 0) return;
      
      var groups = matches[0].Groups;	  
      int d, m, y;
      int.TryParse(groups[2].Value, out d);
      int.TryParse(groups[3].Value, out m);
      int.TryParse(groups[4].Value, out y);
      var date = new DateTime(y, m, d);
      Console.WriteLine(date);
    }
   

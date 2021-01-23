    class MyClass
    {
       static void Main(string[] args)
       {
          string sInput, sRegex;
    
          // The string to search.
          sInput = "123456789";
    
          // The regular expression.
          sRegex = "[0-9][0-9][0-9]";
    
          Regex r = new Regex(sRegex);
    		
          MyClass c = new MyClass();
    
          // Assign the replace method to the MatchEvaluator delegate.
          MatchEvaluator myEvaluator = new MatchEvaluator(c.ReplaceNums);
    
          // Replace matched characters using the delegate method.
          sInput = r.Replace(sInput, myEvaluator);
    
          // Write out the modified string.
          Console.WriteLine(sInput);
       }
    
       public string ReplaceNums(Match m)
       // Replace each Regex match with match + " "
       {
          return m.ToString()+" ";
       }
    
    }

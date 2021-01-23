    var pattern = "TATAAT";
    var input = Console.ReadLine();
    
    var patternIndex = input.IndexOf(pattern);
    
    if(patternIndex >= 0) {
      var answer = input.Substring(patternIndex + pattern.Length, 4);
      Console.WriteLine("YAAY: " + answer);
      
    } else {
      Console.WriteLine("NO");
      
    }

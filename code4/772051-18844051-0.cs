    int i = 0;
    List<Match> matches = new List<Match>();
    while(i < input.Length){
      Match m = Regex.Match(input,"[A-Z][Z-A]");
      if(m.Success){
        matches.Add(i++);
        i = m.Index ++ 1;
      }
    }

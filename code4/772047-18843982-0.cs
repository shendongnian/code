    int i = 0;
    List<Match> matches = new List<Match>();
    while(i < input.Length){
      Match m = Regex.Match(input.Substring(i),"[A-Z]{2}");
      if(m.Success){
        matches.Add(m);
        i += m.Index+1;
      }
    }

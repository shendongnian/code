    public int[] WrongAnswers( char[] reference , char[] answer )
    {
      if ( reference.Length != answer.Length ) throw new ArgumentOutOfRangeException();
      List<int> wrongAnswers = new List<int>() ;
      for ( int i = 0 ; i < reference.Length ; +=i )
      {
        if ( reference[i] != answer[i] ) wrongAnswers.Add(i) ;
      }
      return wrongAnswers.ToArray() ;
    }
    

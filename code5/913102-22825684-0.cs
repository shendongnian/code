    public int[] WrongAnswers( char[] reference , char[] answer )
    {
      if ( reference.Length != answer.Length ) throw new ArgumentOutOfRangeException();
      int[] wrongAnswers = Enumerable
                           .Range(0,reference.Length)
                           .Select( i => new Tuple<int,bool>( i , reference[i]==answer[i] ) )
                           .Where( x => !x.Item2)
                           .Select( x => x.Item1 )
                           .ToArray()
                           ;
      return wrongAnswers ;
    }

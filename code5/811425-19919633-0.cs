    class SurveyId
    {
      static int counter = 0 ;
      static readonly object Syncroot = new object() ;
      
      public override string ToString()
      {
        return string.Format( "SVY{0:0000}" , this.Value )
      }
      public int Value { get ; private set ; }
      
      private SurveyId( int value )
      {
        this.Value = value ;
      }
      
      public static SurveyId GetNext()
      {
        lock ( Syncroot )
        {
          ++counter ;
        }
        return new SurveyId(counter) ;
      }
      
    }

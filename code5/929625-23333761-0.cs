     public static IEnumerable TestCases
      {
        get
        {
          yield return new TestCaseData( 12, 3 ).Returns( 4 );
          yield return new TestCaseData( 12, 2 ).Returns( 6 );
          yield return new TestCaseData( 12, 4 ).Returns( 3 );
          yield return new TestCaseData( 0, 0 )
            .Throws(typeof(DivideByZeroException))
            .SetName("DivideByZero")
            .SetDescription("An exception is expected");
        }
      }  

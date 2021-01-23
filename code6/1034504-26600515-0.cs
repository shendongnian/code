      for ( int a = 0; a < test.Count(); a++ )
      {
        string[,][] ta = test[a];
        for( int i1 = 0; i1 < ta.GetLength( 0 ); i1++ )
        {
          for( int i2 = 0; i2 < ta.GetLength( 1 ); i2++ )
          {
            string[] am = ta[i1, i2];
            for ( int ama = 0; ama < am.Count(); ama++ )
            {
              Console.WriteLine( "{0}", test[ a ][ i1, i2 ][ ama ].ToString() );
            }
          }
        }

    public static class CarouselHelper<T>
    {
      public static IEnumerable<T[,]> BuildCarousel( IEnumerable<T> data, int rows, int cols )
      {
        using ( IEnumerator<T> enumerator = data.GetEnumerator() )
        {
          bool moved = true ;
          do
          {
            T [,] carousel = new T[ rows, cols ] ;
            for ( int i = 0 ; i < rows ; ++i )
            {
              for ( int j = 0 ; j < cols ; ++j )
              {
                moved = enumerator.MoveNext() ;
                T currentCell = moved ? enumerator.Current : default(T) ;
                carousel[i,j] = currentCell ;
              }
            }
            yield return carousel ;
          } while ( moved ) ;
        }
      }
    }

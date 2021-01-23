    T [,] carousel = new T[ rows, cols ] ;
    for ( int j = 0 ; j < cols ; ++j )
    {
      for ( int i = 0 ; i < rows ; ++i )
      {
        moved = enumerator.MoveNext() ;
        T currentCell = moved ? enumerator.Current : default(T) ;
        carousel[i,j] = currentCell ;
      }
    }
    slides.Add(carousel) ;

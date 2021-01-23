    public static CopyFrom<T>( this T[] target , int offset , params T[] source )
    {
      foreach ( T value in values )
      {
         // Throws IndexOutOfRangeException if offset exceeds destination length
         target[offset++] = value ; 
      }
    }

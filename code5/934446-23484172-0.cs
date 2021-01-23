    public static IEnumerable<T> Clone<T>( this IEnumerable<T> list )
    {
      BinaryFormatter serializer = new BinaryFormatter() ;
      
      using ( MemoryStream stream = new MemoryStream() )
      {
        foreach( T item in list )
        {
          
          // serialize
          serializer.Serialize(stream,item) ;
          stream.Flush() ; // probably unneeded for a memory stream, but belts-and-suspenders, right?
          
          // rewind and rehydrate
          stream.Seek(0,SeekOrigin.Begin) ;
          T clone = (T) serializer.Deserialize( stream ) ;
          
          // rewind and clear the memory stream
          stream.Seek(0,SeekOrigin.Begin) ;
          stream.SetLength(0) ;
          
          yield return clone ;
        }
      }
    }
    ...
    List<detail> original = GetListOfDetails() ;
    List<detail> clone    = original.Clone().ToList() ;

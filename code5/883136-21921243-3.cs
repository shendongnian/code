    public void Load( DirectoryInfo root )
    {
      if ( Connection.State == ConnectionState.Closed )
      {
        Connection.Open() ;
        Command.Prepare() ;
      }
      
      Stack<Tuple<int?,DirectoryInfo>> pending = new Stack<Tuple<int?, DirectoryInfo>>();
      pending.Push(new Tuple<int,DirectoryInfo>(null,root) ) ;
      while ( pending.Count > 0 )
      {
        Tuple<int?,DirectoryInfo> dir = pending.Pop() ;
        
        // insert the current directory
        ParentDirectoryId.SqlValue = dir.Item1.HasValue ? new SqlInt32( dir.Item1.Value ) : SqlInt32.Null ;
        DirectoryName.SqlValue     = new SqlString( dir.Item2.Name ) ;
        object o  = Command.ExecuteScalar() ;
        int parentId = (int)(decimal) o ;
        
        // push each subdirectory onto the stack
        foreach ( DirectoryInfo subdir in dir.Item2.EnumerateDirectories() )
        {
          pending.Push( new Tuple<int?, DirectoryInfo>(parentId,subdir));
        }
        
      }
      return ;
    }

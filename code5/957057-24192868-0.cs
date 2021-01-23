    public static IEnumerable<FileSystemInfo> ContentsOfDirectoryTreeRootedAt( string rootDirectory )
    {
      DirectoryInfo root = new DirectoryInfo( rootDirectory ) ;
      if ( !root.Exists ) throw new DirectoryNotFoundException(rootDirectory) ;
      
      foreach( FileSystemInfo entry in root.EnumerateFileSystemInfos(null,SearchOption.AllDirectories) )
      {
        yield return entry ;
      }
      
    }

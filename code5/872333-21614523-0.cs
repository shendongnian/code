    class DirectoryInfoWrapper
    {
      private DirectoryInfo BackingStore { get ; set ; }
      
      public DirectoryInfoWrapper( DirectoryInfo dir )
      {
        this.BackingStore = dir ;
        return ;
      }
       
      public DirectoryInfoWrapper Parent
      {
        get
        {
          DirectoryInfo parent = this.BackingStore.Parent ;
          return parent != null ? new DirectoryInfoWrapper(parent) : null ;
        }
      }
      
      public string Name
      {
        get
        {
          return this.BackingStore.Name ;
        }
      }
      
      public DirectoryInfoWrapper[] Subdirectories
      {
        get
        {
          return this
                 .BackingStore
                 .EnumerateDirectories()
                 .Select( x => new DirectoryInfoWrapper(x) )
                 .ToArray()
                 ;
        }
      }
      
      public string[] Files
      {
        get
        {
          return this
                 .BackingStore
                 .EnumerateFiles()
                 .Select( x => x.Name )
                 .ToArray()
                 ;
        }
      }
         
    }

    struct UriCategory
    {
      public UriCategory( string name ) : this()
      {
        if ( string.IsNullOrWhiteSpace(name) ) throw new ArgumentException("category name can't be null, empty or whitespace","name");
        this.Name = name ;
        return ;
      }
      
      public readonly string Name  ;
      
      public override string ToString() { return this.Name ; }
      
    }
    
    struct UriAttribute
    {
      public UriAttribute( string major , string minor ) : this()
      {
        bool parseSuccessful ;
        
        parseSuccessful = int.TryParse( major , out Major ) ;
        if ( !parseSuccessful ) throw new ArgumentOutOfRangeException("major") ;
        
        parseSuccessful = int.TryParse( minor , out Minor ) ;
        if ( !parseSuccessful ) throw new ArgumentOutOfRangeException("minor") ;
        
        return ;
      }
      
      public readonly int Major  ;
      public readonly int Minor ;
      
      public override string ToString() { return string.Format( "{0}_{1}" , this.Major , this.Minor ) ; }
      
    }

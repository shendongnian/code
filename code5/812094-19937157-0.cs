    public object GetHeaderInfo(string agentId, string headerName) 
    {
      object instance ;
      switch ( headerName )
      {
      case "flyer"   : instance = Service.GetFlierHeaderInfo( agentId ) ; break ;
      case "general" : instance = Service.GetHeaderInfo(      agentId ) ; break ;
      
      default        : throw new ArgumentOutOfRangeException("headerName" ) ;
      }
      return instance ;
    }

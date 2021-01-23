    public Class ConnectionBase
    {  
      public string ConnectionString{ get; private set;}
      public ConnectionBase(Enum connection)
      {
        Switch(connection)
        
        Case //your value:
         ConnectionString=ConfigurationManager.ConnectionStrings["Your Connection String        from Web Config"]   
        
       and so on.....
     
      }
      
    
    }

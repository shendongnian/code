    static IEnumerable<string> ReadGuidsFromXml( TextReader input )
    {
      using ( XmlReader reader = XmlReader.Create( input ) )
      {
        while ( reader.Read() )
        {
          if ( reader.NodeType != XmlNodeType.Element ) continue ;
          
          for ( bool hasAttributes = reader.MoveToFirstAttribute() ; hasAttributes ; hasAttributes = reader.MoveToNextAttribute() )
          {
            if ( !string.Equals( reader.Name , "id" , StringComparison.OrdinalIgnoreCase ) ) continue ;
            
            Guid guid;
            if ( Guid.TryParse( reader.Value , out guid ) )
            {
              yield return guid;
            }
            
          }
          
        }
        
      }
    }

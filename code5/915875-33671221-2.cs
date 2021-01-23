    public static string EscapeXml( this string s )
    {
      string toxml = s;
      if ( !string.IsNullOrEmpty( toxml ) )
      {
        // replace literal values with entities
        toxml = toxml.Replace( "'", "&apos;" );
        toxml = toxml.Replace( "\"", "&quot;" );
        toxml = toxml.Replace( ">", "&gt;" );
        toxml = toxml.Replace( "<", "&lt;" );
        toxml = toxml.Replace( "&", "&amp;" );
      }
      return toxml;
    }
    public static string UnescapeXml( this string s )
    {
      string unxml = s;
      if ( !string.IsNullOrEmpty( unxml ) )
      {
        // replace entities with literal values
        unxml = unxml.Replace( "&apos;", "'" );
        unxml = unxml.Replace( "&quot;", "\"" );
        unxml = unxml.Replace( "&gt;", ">" );
        unxml = unxml.Replace( "&lt;", "<" );
        unxml = unxml.Replace( "&amp;", "&" );
      }
      return unxml;
    }

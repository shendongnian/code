    public static string UnescapeXml( this string s )
    {
      string unxml = s;
      if ( !string.IsNullOrEmpty( unxml ) )
      {
        // replace entities with literal values
        unxml = unxml.Replace( "&apos;", "'" );
        unxml = unxml.Replace( "&quot;", "\"" );
        unxml = unxml.Replace( "&gt;", "&gt;" );
        unxml = unxml.Replace( "&lt;", "&lt;" );
        unxml = unxml.Replace( "&amp;", "&" );
      }
      return unxml;
    }
    public static string UnescapeXml( this string s )
    {
      string unxml = s;
      if ( !string.IsNullOrEmpty( unxml ) )
      {
        // replace entities with literal values
        unxml = unxml.Replace( "&apos;", "'" );
        unxml = unxml.Replace( "&quot;", "\"" );
        unxml = unxml.Replace( "&gt;", "&gt;" );
        unxml = unxml.Replace( "&lt;", "&lt;" );
        unxml = unxml.Replace( "&amp;", "&" );
      }
      return unxml;
    }

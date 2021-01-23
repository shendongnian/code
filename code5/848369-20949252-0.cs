    internal void alter( string param, bool replace = false, string value = null )
    {
        //here
        string buf;
        string bufPath = path.Substring( 0, path.Length - Path.GetExtension( path ).Length ) + "_buf.txt";
        using ( System.IO.StreamReader reader = new System.IO.StreamReader( path ) )
        {
            string paramWithSpace = param + " ";
            using ( System.IO.StreamWriter writer = new StreamWriter( bufPath ) )
            {
                while ( ( buf = reader.ReadLine() ) != null )
                {
                    if ( !buf.StartsWith( paramWithSpace ) )
                        writer.WriteLine( buf );
                    else if ( replace )
                        writer.WriteLine( paramWithSpace + value );
                }
            }
        }
            //there
        File.Delete( path );
        File.Move( bufPath, path );
    }

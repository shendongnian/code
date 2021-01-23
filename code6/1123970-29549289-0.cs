    string[] lines = File.ReadAllLines( filename );
    foreach ( string line in lines )
    {
      string[] col = line.Split( new char[] {','} );
      // process col[0], col[1], col[2]
    }

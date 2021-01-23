    using( StreamReader input = new StreamReader("somefile.txt") )
    {
       List<int> bounds = new List<int>();
       for( string line = input.ReadLine(); line != null; line = input.ReadLine() )
       {
          if( line.Length > 0 && line[0] == '-' )
             bounds.Clear();
          if( Regex.IsMatch(line, "^ *=[ =]*$") ) // This is a column header
          {
             bounds.Clear();
             for( int i = 1; i<line.Length; ++i )
                if( line[i - 1] != line[i] )
                   bounds.Add(i);
          }
          else if( bounds.Count > 0 )
          {
             List<string> cells = new List<string>();
             string padLine = line.PadRight(bounds[bounds.Count-1]);
             for( int i=0; i<bounds.Count; i += 2 )
                cells.Insert(i / 2, padLine.Substring(bounds[i], bounds[i+1]));
             // retrieve data cells[7] (column 7) here and store elsewhere.  
          }
       }
    }

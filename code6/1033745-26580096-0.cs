    void Run() {
        
        Dictionary< String, List<Int32> > dict = new Dictionary< String, List<Int32> >();
        
        foreach(Tuple<String,Int32> wordOccurrence in GetWords()) {
            String word = wordOccurrence.Item1;
            Int32 line = wordOccurrence.Item2;
            if( !dict.ContainsKey( word  ) ) dict.Add( word , new List<Int32>() );
            dict[ word ].Add( line );
        }
        
        foreach(String word in dict.Keys) {
            
            Console.WriteLine("\"{0}\" appeared {1} times, on these lines:", word, dict[word].Count);
            foreach(Int32 line in dict[word]) Console.WriteLine("\t{0}", line );
            Console.WriteLine("");
        }
    }
    
    IEnumerable< Tuple<String,Int32> > GetWords() {
        
        using(StreamReader rdr = new StreamReader("fileName")) {
            StringBuilder sb = new StringBuilder();
            Int32 nc; Char c;
            Itn32 lineNumber = 0;
            while( (nc = rdr.Read() != -1 ) {
                c = (Char)nc;
                
                if( Char.IsWhitespace(c) ) {
                    if( sb.Length > 0 ) {
                        yield return new Tuple( sb.ToString(), lineNumber );
                        sb.Length = 0;
                    }
                    if( c == '\n' ) lineNumber++;
                } else {
                    sb.Append( c );
                }
            }
            if( sb.Length > 0 ) yield return new Tuple( sb.ToString(), lineNumber );
        }
    }            

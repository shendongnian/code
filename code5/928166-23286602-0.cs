    enum State {
        InQuotes,
        InValue
    }
    List<String> result = new List<String>();
    using(TextReader rdr = new StringReader( line )) {
        
        State state = State.InValue;
        StringBuilder sb = new StringBuilder();
        
        Int32 nc; Char c;
        while( (nc = rdr.Read()) != -1 ) {
            c = (Char)nc;
            
            switch( state ) {
                
                case State.InValue:
                    
                    if( c == '"' ) {
                        state = State.InQuotes;
                    } else if( c == ',' ) {
                        result.Add( sb.ToString() );
                        sb.Length = 0;
                    } else {
                        sb.Append( c );
                    }
                    break;
                case State.InQuotes:
                    
                    if( c == '"' ) {
                        state = State.InValue;
                    } else {
                        sb.Append( c );
                    }
                    break;
            } // switch
        } // while
        if( sb.Length > 0 ) result.Add( sb.ToString() );
    } // using

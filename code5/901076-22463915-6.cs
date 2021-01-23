    string sLog =
    @"
    2014-02-13 16:06:52,226 [8] ERROR solucao.projeto.arquivo - AutenticarUsuario
    System.Threading.ThreadAbortException: O thread estava sendo anulado.
        em System.Threading.Thread.AbortInternal()
        em System.Threading.Thread.Abort(Object stateInfo)
        em System.Web.HttpResponse.End()  
    2014-02-13 16:06:52,226 [8] ERROR solucao.projeto.arquivo - AutenticarUsuario
    System.Threading.ThreadAbortException: O thread estava sendo anulado.
       em System.Threading.Thread.AbortInternal()
       em System.Threading.Thread.Abort(Object stateInfo)
       em System.Web.HttpResponse.End()
    ";
    
    Regex Rx = new Regex(
    @"
     (?ms)                                   # Multi-line, Dot-All
     ^                                       # Beginning of line
     (?<data> [^\[\]\r\n]+ )                 # (1), Date/time                                             
     [ \t]+                                  # Horizontal whitespace ( could use '\h' instead )
     \[                                      # '['
     (?<thread> [0-9]+ )                     # (2), Thread number                                             
     \]                                      # ']'
     [ \t]+                                  # Horizontal whitespace 
     (?<nivel> [A-Z]+ )                      # (3), Error                                    
     [ \t]+                                  # Horizontal whitespace
     (?<classe>                              # (4 start), Class                                    
          (?: [A-Za-z]+ \. )+
          [A-Za-z]+ 
     )                                       # (4 end)
     [ \t]+                                  # Horizontal whitespace
     -                                       # '-'
     [ \t]+                                  # Horizontal whitespace
     (?<message>                             # (5 start), Message                           
          (?:                                     # Cluster group
               (?!                                     # Lookahead
                    ^                                       # Not the start of a new exception
                    [^\[\]\r\n]+                            # ( basically, not the above code )
                    [ \t]+ 
                    \[
                    [0-9]+ 
                    \]
               )                                       # End Lookahead
               .                                       # Continue to grab characters
          )+                                      # End Cluster group, do 1 or more times
     )                                       # (5 end)
    ", RegexOptions.IgnorePatternWhitespace);
    
    Match matchX = Rx.Match( sLog );
    while ( matchX.Success )
    {
        Console.WriteLine( "----------------------" );
        Console.WriteLine( "New Exception" );
        Console.WriteLine( "Date:\t" + matchX.Groups[1] );
        Console.WriteLine( "Thread:\t" + matchX.Groups[2] );
        Console.WriteLine( "Err:\t" + matchX.Groups[3] );
        Console.WriteLine( "Class:\t" + matchX.Groups[4] ) ;
        Console.WriteLine( "Msg --" );
        Console.WriteLine( matchX.Groups[5] );
        matchX = matchX.NextMatch();
    }

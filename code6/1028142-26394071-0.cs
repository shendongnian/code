    StringBuilder sb = new StringBuilder();
    while( true ) {
        
        ConsoleKeyInfo key = Console.ReadKey();
        if( !Char.IsControl( key.KeyChar ) ) {
            
            sb.Append( key.KeyChar );
            if( sb.ToString() == "magic!" ) {
                
                Console.Write("\r");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write( sb.ToString() );
                Console.ResetColor();
            }
        } else {
            sb.Length = 0;
        }
    }

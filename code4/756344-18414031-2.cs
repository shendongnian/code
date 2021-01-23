    if ( userinput != null )
    {
        userinput = userinput.ToUpper ();
        for ( int i = 0; i < userinput.Length; i++ )
        {
            switch ( userinput[i] )
            {
                case '1':
                case 'A':
                    ...
                    break;
    
                ...
                default:
                    // Handle invalid characters here
                    break;
            }
        }
    }

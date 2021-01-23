    string input = @"a,b,c,d,""e,f"",g,h";
    string[] pieces = input.Split('"');
    for ( int i = 0; i < pieces.Length; i++)
    {
        if ( i % 2 != 0 )
        {
            pieces[i] = string.Join(" ",pieces[i].Split(','));
        }
    }
    string output = string.Concat(pieces);

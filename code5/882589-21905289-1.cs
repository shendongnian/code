    string input = "a,b,c,d,\"e,f\",g,h";
    string[] pieces = input.Split('"');
    for ( int i = 1; i < pieces.Length; i += 2 )
    {
        pieces[i] = string.Join(" ", pieces[i].Split(','));
    }
    string output = string.Join("\"", pieces);
    Console.WriteLine(output);
    // output: a,b,c,d,"e f",g,h

    string[] strings = myString.Split( new string[]{ " " }, StringSplitOptions.RemoveEmptyEntries );
    int[] ints = new int[ strings.Length ];
    for( int i = 0; i < ints.Length; ++i )
    {
        if( !int.TryParse( strings[i], out ints[i] )
        {
              // error
        }
    }

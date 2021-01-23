    int[] indices = new int[] { 2, 5, 11 };
    string yourLongString = "blahblahblah";
    
    foreach( var index in indices.Reverse() )
    {
    	yourLongString = yourLongString.Insert( index - 1, "-" );
    }

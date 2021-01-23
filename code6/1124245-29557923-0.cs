    private static object _sybcRoot = new object();
    
    public static void Add( string key, string res)
        lock( _sybcRoot ) {
           ConnectionList.Add( key, res );
        }
    }

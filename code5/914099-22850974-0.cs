    public List<T> MakeListOf3<T>( T val )
    {
        var list = new List<T>();
        list.Add( val );
        list.Add( val );
        list.Add( val );
        return list;
    }

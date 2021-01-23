    public void Method(string name, DateTime? date)
    {
        if( name == null ){ } // you may want: if( string.IsNullOrEmpty( name ) ){}
        if( date.HasValue ){ }
    }

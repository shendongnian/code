    public byte[] Foo { get ; private set ; }
    .
    .
    .
    Foo.CopyFrom( 0, 1,2,3,4 ) ;
    .
    .
    .
    Foo.CopyFrom( 1, new byte[]{1,2} ) ;

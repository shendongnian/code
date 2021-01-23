    if( obj is SpecificClass1 sc1 )
    {
       sc1.SomeMethod1();
    }
    else if( obj is SpecificClass2 sc2 )
    {
       sc2.SomeMethod2();
    }
    else if( obj is SpecificClass3 sc3 )
    {
       sc3.SomeMethod3();
    }
    else
    {
       throw new exception();
    }

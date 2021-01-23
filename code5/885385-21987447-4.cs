    SpecificClass1 sc1;
    SpecificClass2 sc2;
    SpecificClass3 sc3;
    if( obj.TryCast(out sc1) )
    {
        sc1.SomeMethod1();
    }
    else if( obj.TryCast(out sc2) )
    {
        sc2.SomeMethod2();
    }
    else if( obj.TryCast(out sc3) )
    {
        sc3.SomeMethod3();
    }

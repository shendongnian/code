    var specClass1 = obj as SpecificClass1;
    var specClass2 = obj as SpecificClass2;
    var specClass3 = obj as SpecificClass3;
    if(specClass1 != null)
       specClass1.SomeMethod1();
    else if(specClass2 != null)
       specClass2.SomeMethod2();
    else if(specClass3 != null)
       specClass3.SomeMethod3();

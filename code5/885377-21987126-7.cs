    var specClass1 = obj as SpecificClass1;
    if (specClass1 != null)
       specClass1.SomeMethod1();
    else
    {
        var specClass2 = obj as SpecificClass2;
        if (specClass2 != null)
            specClass2.SomeMethod2();
        else
        {
            var specClass3 = obj as SpecificClass3;
            if (specClass3 != null)
                specClass3.SomeMethod3();
        }
    }

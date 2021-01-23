    #define abc   
    namespace ConsoleApplication2
    {
        class Class5
        {
            public
    #if abc
     int
    #else
        string
    #endif
     Foo()
            {
    #if abc
                return 7;
    #else
        return "aa"
    #endif
            }
    
            public void Bar()
            {
                #if abc
                int
    #else
        string
    #endif
     thing = Foo();
            }
        }
    }

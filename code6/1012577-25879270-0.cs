    class MySingletonClass
    {
        //-----------------------------------------
        // here, we hide the static implementations
        //-----------------------------------------
        private static int privateFoo()
        {
            /* do something useful here */
        }
        private static string privateBar()
        {
            /* do something useful here */
        }
        //---------------------------------------
        // and expose them via an object instance
        //---------------------------------------
        public int Foo()
        {
            return privateFoo() ;
        }
        public string Bar()
        {
            return privateBar() ;
        }
    }

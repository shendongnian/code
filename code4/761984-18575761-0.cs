        private class MyClass
        {
            public MyClass()
            {
                ldarg.0
                call     System.Object..ctor()
                ret
            }
            public override string ToString()
            {
                locals:
                    V_0: string 
                ldarg.0
                call     string System.Object.ToString()
                stloc.0
                ldloc.0
                ret
            }
        } // class MyClass
        private class Test
        {
            public Test()
            {
                ldarg.0
                call     System.Object..ctor()
                ret
            }
            public override string ToString()
            {
                locals:
                    V_0: string 
                ldarg.0
                call     string System.Object.ToString()
                stloc.0
                ldloc.0
                ret
            }
        } // class Test

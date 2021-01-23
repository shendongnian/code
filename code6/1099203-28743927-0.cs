    public class Container
    {
        private class Foo
        {
            protected int field;
            private class FurtherNested
            {
                // Valid: a nested class has access to all the members
                // of its containing class
                void CheckAccess(Foo foo)
                {
                    int x = foo.field; 
                }
            }
        }
        private class Bar : Foo
        {
            void CheckAccess(Foo foo)
            {
                // Invalid - access to a protected member
                // must be through a reference of the accessing
                // type (or one derived from it)
                int x = foo.field; 
            }
            void CheckAccess(Bar bar)
            {
                // Valid
                int x = bar.field;
            }
        }
        private class Baz
        {
            void CheckAccess(Foo foo)
            {
                // Invalid: this code isn't even in a class derived
                // from Foo
                int x = foo.field;
            }
        }
    }

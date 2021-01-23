    	public class Test
        {
            public int x, y, z;//....
            public void Foo()
            {
                x = FooBody();
            }
            [Pure]
            private int FooBody()
            {
                int value = x;
                //work with value as x
                return value;
            }
        }

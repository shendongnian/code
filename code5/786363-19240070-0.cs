    public class Outer
    {
        // Code outside the body of Outer cannot call this. But
        // the code in Nested *is* inside the body of Outer, so it's okay.
        private void Foo()
        {
        }
        private class Nested
        {
            internal void Bar()
            {
                new Outer().Foo();
            }
        }
    }

    namespace Foo
    {
        class Bar  // Implicitly internal class Bar
        {
            int x; // Implicitly private int x
            void Baz() {} // Implicitly private void Baz() {}
            class Nested // Implicitly private class Nested
            {
            }
        }
    }

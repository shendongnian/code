    class Foo {
        private String _bar;
        public Int32 Baz(String qux) {
            return String.Concat( _bar, qux ).Length;
        }
    }
    // Usage:
    Foo foo = new Foo();
    Console.WriteLine( foo.Baz("lulz") );

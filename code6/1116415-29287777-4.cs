    class Foo {
          readonly int _bar;
          readonly string _baz;
          public Foo(int bar, string baz) {
               _bar = bar;
               _baz = baz;
          }
        public int Bar
        {
            get { return _bar; }
        }
        public string Baz
        {
            get { return _baz; }
        }
    }

    class Foo {
          int _bar;
          string _baz;
          public Foo(int bar, string baz) {
               Bar = bar;
               Baz = baz;
          }
        public int Bar
        {
            get { return _bar; }
            set { _bar = value; }
        }
        public string Baz
        {
            get { return _baz; }
            set { _baz = value; }
        }
    }

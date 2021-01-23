    public void Foo(string x) { Baz(x, false); }
    public void Bar(string x) { Baz(x, true); }
    private void Baz(string x, bool y) {
      if (x == null) throw new ArgumentNullException("x");
      // ...
    }

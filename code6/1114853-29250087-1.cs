    class Bar
    {
        public Bar(IBouncer bouncer) { ... }
    
        public void Foo()
        {
            // foo-ing
            foreach (var f in bouncer.WhoIsInside) f.FooHappened();
        }
    }

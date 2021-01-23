    class Thing
    {
        public void Process()
        {
           if(Foo!=null) Foo();
           if(Bar!=null) Bar();
        }
        public Action Foo {get;set;}
        public Action Bar {get;set;}
    }
    var a=new Thing() {Foo=DoFoo};
    var b=new Thing() {Bar=DoBar};
    a.Process();
    b.Process();

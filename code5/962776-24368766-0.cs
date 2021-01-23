    var ctx = new SomeType();
    ctx.a = new A { P1 = .... };
    ctx.b = new B { P1 = .... };
    AssignAndDoSth(a.P1, b.P1, new Action(ctx.SomeMethod));
    ...
    class SomeType {
        public A a;
        public B b;
        public void SomeMethod()
        {
            b.P1 = a.P1;
        }
    }

    class Parent
    {
        protected virtual int MyMethod()
        {
            return 1;
        }
    }
    class Child : Parent
    {
        protected override int MyMethod()
        {
            return 2;
        }
    }
    // ...
    Parent p = new Parent();
    Parent c = new Child();
    var result = p.MyMethod(); // will return 1
    var result = c.MyMethod(); // will return 2

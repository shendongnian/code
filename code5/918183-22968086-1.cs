    class Base
    {
        protected void Foo() {}
        
        void Test()
        {
            Foo(); // legal
            this.Foo(); // legal
            new Base().Foo(); // legal
            new Derived().Foo(); // legal
            new MoreDerived().Foo(); // legal
        }
    }
    class Derived : Base
    {
        void Test1()
        {
            Foo(); // legal
            this.Foo(); // legal
            new Base().Foo(); // illegal !
            new Derived().Foo(); // legal
            new MoreDerived().Foo(); // legal
        }
    }
    class MoreDerived : Derived
    {
        void Test2()
        {
            Foo(); // legal
            this.Foo(); // legal
            new Base().Foo(); // illegal !
            new Derived().Foo(); // illegal !
            new MoreDerived().Foo(); // legal
        }
    }

    void Main()
    {
        Foo foo = Foo.GetInstance(new BarBazAndFoobarImplementer());
    }
    public sealed class Foo {
        private Foo(Bar value) {
            this.Thing1 = value.BarProperty;
            this.Thing2 = ((IBaz)value).IBazProperty;
            this.Thing3 = ((IFoobar)value).IFoobarProperty;
        }
        
        public static Foo GetInstance<T>(T value) where T : Bar, IBaz, IFoobar {
            return new Foo(value);
        }
    }

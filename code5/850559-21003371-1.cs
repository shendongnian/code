    public abstract class Parent
    {
        protected bool foo;
        protected Parent() { } // So all instances are created through createAnotherX
        public abstract int Enter(); // To override in child classes
        // Option 1: use generics
        public static T createAnother1<T>(bool f) where T : Parent, new()
        {
            T p = new T();
            p.foo = f;
            return p;
        }
        // Option 2: use the runtime type
        public static Parent createAnother2(Type t, bool f)
        {
            Parent p = Activator.CreateInstance(t) as Parent;
            p.foo = f;
            return p;
        }
        // Examples
        public static void Main()
        {
            Parent p1 = Parent.createAnother1<Child>(true);
            Parent p2 = Parent.createAnother2(typeof(Child), true);
        }
    }
    // the child class only has to worry about overriding Enter()
    public class Child : Parent
    {
        public override int Enter()
        {
            return 1;
        }
    }

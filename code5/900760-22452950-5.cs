    public interface IHasFooThatMustBeCalledInConstructor {
        void Foo();
    }
    public abstract class A: IHasFooThatMustBeCalledInConstructor {
        public A() {
            Foo();
        }
    
        public abstract void Foo();
    }
    
    public class B: A {
        public B(string param) {}
        public void Foo() { };
    }

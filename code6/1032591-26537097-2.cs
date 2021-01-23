    public abstract class Parent { 
        protected abstract void Load<T>(T param); 
    }
    public class Child : Parent {
        protected void Load() {}
        protected override void Load<T>(T param) { // do nothing? }
    }

    public abstract class Parent { 
        protected abstract void Load<T>(T param); 
    }
    public class Child {
        protected void Load() {}
        private override void Load<T>(T param) { // do nothing? }
    }

    public interface TestC {
        T DoSomething<T,X>(X x) where T : TestA<X>;
    }
    public class TestCImpl : TestC {
        public T DoSomething<T,X>(X x) where T : TestA<X>
            //Do something
            return default(T);
        }
    }

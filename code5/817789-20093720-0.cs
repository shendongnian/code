    }
    class TImpl:ITest
    {
        
    }
    interface ITest<out T>
    {
        T get();
    }
    class Test<T>:ITest<T> 
              where T:ITest
    {
        public T get()
        {
            return default(T);
        }
    }

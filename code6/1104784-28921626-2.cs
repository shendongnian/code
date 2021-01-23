    class A<T>
      where T : struct
    {
       void foo()
       {
          int x = 0;
          T y = (T)Convert.ChangeType(x, typeof(T));  
       }
    }

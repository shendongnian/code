            public class Wrapper<T>
            {
               public Wrapper(T wrapped)
               {
                   this.Wrapped = wrapped;
               }
               public T Wrapped { get; private set; }
               public implicit operator T (Wrapper<T> wrapper)
               {
                   return wrapper.Wrapped;
               }
            }
            public class WrappedCanvas : Wrapper<Canvas>
            {
                private Object data;
                public void SafeTransform(...);
            }

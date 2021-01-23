    public class MyClass<T> : MyInterface<T>
    {
        public IEnumerable<TOutput> AsEnumerable<TOutput>()
        {
           var converter = TypeDescriptor. GetConverter(typeof(T));
           //do what you want
           foreach(var item in someList)
           {
               var result = converter.ConvertTo(item, typeof(TOutput));
               yield return (TOutput)result:
           }
        }
    }

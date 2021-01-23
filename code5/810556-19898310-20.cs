    public class MyClass<T> where T: IController
    {
        public T[] Items;
        public void DoTheWebJob()
        {
            Items[0].Execute(null);
        }
    }

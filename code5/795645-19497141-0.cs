    public abstract class MyBaseClass<T>
    {
        protected abstract MyBaseClass<T> Get(T id);
    }
    public class MyClass : MyBaseClass<string>
    {
        protected override MyBaseClass<string> Get(string id)
        {
            return FindById(id);//implement your logic
        }
    }

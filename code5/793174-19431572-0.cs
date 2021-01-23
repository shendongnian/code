    public class Factory<T>
    {
        public Factory()
        {
            _Mappings = new Dictionary<string,Func<IInterface<T>>>(2);
            
            _Mappings.Add("MyClass1", () => new MyClass1() as IInterface<T>);
            _Mappings.Add("MyClass2", () => new MyClass2() as IInterface<T>);
        }
        public IInterface<T> Get(string typeName)
        {
            Func<IInterface<T>> func;
            if (_Mappings.TryGetValue(typeName, out func))
            {
                return func();
            }
            else
                throw new NotImplementedException();
        }
        readonly Dictionary<string, Func<IInterface<T>>> _Mappings;
    }
    public class MyClass1 : IInterface<int>
    {
        public int Method()
        {
            throw new NotImplementedException();
        }
    }
    public class MyClass2 : IInterface<string>
    {
        public string Method()
        {
            throw new NotImplementedException();
        }
    }
    public interface IInterface<T>
    {
        T Method();
    }

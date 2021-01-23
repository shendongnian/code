    public interface IContainableObject 
    { 
    }
    public interface IMyGenericType<in T> 
        where T:IContainableObject
    {
        string key{get;set;}
    }
    public abstract class MyGenericType<T> : IMyGenericType<IContainableObject>
        where T : IContainableObject
    {
        public string key{get;set;}
    }
    public class MyTypedClass:MyGenericType<DerivedContainableObject>
    {
        
    }
    public class DerivedContainableObject:IContainableObject
    {
    }
 
    public class Registry
    {
        private Dictionary<String, IMyGenericType<IContainableObject>> m_elementDictionary = new Dictionary<String, IMyGenericType<IContainableObject>>();
        public void Register<T>(MyGenericType<T> objectToRegister)       
            where T:IContainableObject
        {
            m_elementDictionary[objectToRegister.key] = objectToRegister; //This now work
        }
        public void ExampleMethod() 
        {
            Register(new MyTypedClass());
        }
    }
}

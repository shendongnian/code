    public interface IMyClassFactory 
    {
        // For simplification it returns MyClass. For sake of decoupling, 
        // it should return IMyClass interface which is implemented by MyClass
        MyClass Create(string myParameter);
    }
    // In your application layer, if you use n-layered architecture
    public class MyClassFactory : IMyClassFactory 
    {
        public MyClass Create(string myParameter) 
        {
            return new MyClass(
                SimpleIoc.Default.GetInstance<Dependency1>(),
                SimpleIoc.Default.GetInstance<Dependency2>(),
                myParameter
            );
        }
    }

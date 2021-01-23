    [Guid("98F2287A-1DA3-4CC2-B808-19C0BE976C08")]
    public interface _ClassFactory
    {
        Class1 CreateClass1(string message);
    }
    [Guid("C7546E1F-E1DB-423B-894C-CB19607972F5")]
    [ProgId("Project.ClassFactory")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ClassFactory : _ClassFactory
    {
        public Class1 CreateClass1(string message)
        {
            return new Class1(message);
        }
    }

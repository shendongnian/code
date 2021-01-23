    class Program {
        static void Main(string[] args) {
            //Declare instances
            BaseClass myClass = new Class2();
            BaseClass otherClass = new Class1();
            //Invoke the action method which will match based on the BaseClass type
            Action(myClass);
            Action(otherClass);
            Console.ReadLine();
        }
        public static void Action(BaseClass classType) {
            //Remove the compile-time type so the runtime can select the method based on signature
            dynamic aClass = classType;
            ServiceMethod(aClass);
        }
        public static void ServiceMethod(dynamic input) {
            Methods(input);
        }
        public static void Methods(Class1 classType) {
            Console.WriteLine("Class1");
            Debug.WriteLine("Class1");
        }
        public static void Methods(Class2 classtype) {
            Console.WriteLine("Class2");
            Debug.WriteLine("Class2");
        }
        public static void Methods(Class3 classType) {
            Console.WriteLine("Class3");
            Debug.WriteLine("Class3");
        }
    }
    public abstract class BaseClass { //This could also be an interface
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class Class1 : BaseClass {
    }
    public class Class2 : BaseClass{
    }
    public class Class3 : BaseClass {
    }

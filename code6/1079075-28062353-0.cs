    interface IContainableObject { 
    }
    public interface MyGenericType<out T> {
        string key();
    }
    interface IDerivedContainableObject : IContainableObject {
    }
    class Program {
        private static Dictionary<String, MyGenericType<IContainableObject>> m_elementDictionary = new Dictionary<String, MyGenericType<IContainableObject>>();
        public static void Register<T>(T objectToRegister)
            where T : MyGenericType<IContainableObject> {
                m_elementDictionary[objectToRegister.key()] = objectToRegister;
        }
        static void Main(string[] args) {
            MyGenericType<IDerivedContainableObject> x = null;
            MyGenericType<IContainableObject> y = x;
            Register(y);
        }
    }

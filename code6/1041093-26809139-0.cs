    public static class SingletonHelper
    {
        public static T GetInstance<T>() where T : class
        {
            return (T)GetInstance(typeof(T));
        }
        public static object GetInstance(Type type) 
        {
            if (type == null)
                throw new ArgumentNullException();
            if (!type.IsClass)
                throw new InvalidOperationException();
            var abstractType = typeof(Singleton<>);
            var genericType = abstractType.MakeGenericType(new Type[] { type });
            var instanceMethod = genericType.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public).GetGetMethod();
            return instanceMethod.Invoke(null, null);
        }
    }
    public class Singleton<T> where T : class
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }
        /// <summary>
        /// Private nested class which acts as singleton class instantiator. This class should not be accessible outside <see cref="Singleton<T>"/>
        /// </summary>
        class Nested
        {
            /// <summary>
            /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            /// </summary>
            static Nested()
            {
            }
 
            /// <summary>
            /// Static instance variable
            /// </summary>
            internal static readonly T instance = (T)Activator.CreateInstance(typeof(T), true);
        }        
        public static T Instance { get { return Nested.instance; } }
    }

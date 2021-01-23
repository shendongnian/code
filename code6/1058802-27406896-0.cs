    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    
    namespace ConsoleApplication3
    {
        [System.AttributeUsage(System.AttributeTargets.Class)]
        public class HandlerAttribute : Attribute
        {
            protected string fType;
    
            public HandlerAttribute(string type)
            {
                fType = type;
            }
    
            public string HandlerType
            {
                get { return fType; }
                set { fType = value; }
            }
        }
    
        public interface IHandlerA
        {
            //commom interface for handlers of type HandlerA
            string Name { get; }
        }
    
        public enum EHandlerATypes
        {
            A,
            B
        }
    
        [HandlerAttribute("A")]
        public class SpecificHandlerATypeA : IHandlerA
        {
    
            public string Name
            {
                get { return "HandlerA type A"; }
            }
        }
    
        [HandlerAttribute("B")]
        public class SpecificHandlerATypeB : IHandlerA
        {
    
            public string Name
            {
                get { return "HandlerA type B"; }
            }
        }
    
        public class HandlerA
        {
            public Dictionary<EHandlerATypes, Type> fHandlerACollection;
    
            public HandlerA()
            {
                fHandlerACollection = HandlerSearchEngine.GetHandlersList<EHandlerATypes, IHandlerA>(new Assembly[] { this.GetType().Assembly });
            }
        }
    
        public static class HandlerSearchEngine
        {
            public static Dictionary<TEnum, Type> GetHandlersList<TEnum, THandler>(Assembly[] assemblyList)
            {
                if (!typeof(TEnum).IsEnum)
                    throw new Exception("Invalid parameter TEnum");
    
                Dictionary<TEnum, Type> dic = new Dictionary<TEnum, Type>();
    
                foreach(Assembly assembly in assemblyList)
                {
                    var types = assembly.GetTypes().Where(t => t.IsClass && typeof(THandler).IsAssignableFrom(t));
                    foreach(Type type in types)
                    {
                        HandlerAttribute ha = type.GetCustomAttribute<HandlerAttribute>();
                        TEnum handlerType = (TEnum) Enum.Parse(typeof(TEnum), ha.HandlerType, true);
    
                        if (dic.ContainsKey(handlerType))
                            throw new Exception("One handler with the same handler type already exists in the collection");
    
                        dic[handlerType] = type;
                    }
                }
    
                return dic;
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                HandlerA a = new HandlerA();
                foreach(KeyValuePair<EHandlerATypes, Type> pair in a.fHandlerACollection)
                {
                    IHandlerA ha = (IHandlerA)Activator.CreateInstance(pair.Value);
                    Console.WriteLine(ha.Name);
                }
    
                Console.ReadKey();
            }
        }
    }

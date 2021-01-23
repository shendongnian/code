    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class Test
    {
        static bool ImplementsGenericInterface(Type type, Type genericInterface)
        {
            return type.GetInterfaces().Any(i => i.GetGenericTypeDefinition() == genericInterface);
        }
    
        static object TransformObject(object oldObject, Type newType, Func<object, object> transform)
        {
            if (ImplementsGenericInterface(oldObject.GetType(), typeof(IList<>))
               && ImplementsGenericInterface(newType, typeof(IList<>)))
            {
                object newCollection = Activator.CreateInstance(newType);
                var method = newType.GetMethod("Add");
    
                foreach (var item in (IEnumerable)oldObject)
                {
                    var newItem = transform(item);
                    method.Invoke(newCollection, new object[] { newItem });
                }
    
                return newCollection;
            }
    
            return null;
        }
    
        public static void Main()
        {
            var list1 = new List<int>() { 1, 2, 3 };
    
            var list2 = (List<string>)TransformObject(list1, typeof(List<string>), o => o.ToString());
    
            foreach (var item in list2)
                Console.WriteLine(item);
    
            Console.ReadKey();
        }
    }

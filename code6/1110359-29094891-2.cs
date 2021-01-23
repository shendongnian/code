    public class Program
    {
        static void Main(string[] args)
        {
            List<Type> allEntityClasses = (from x in Assembly.GetAssembly(typeof(Entity))
                                               .GetTypes().Where(t=>typeof(Entity).IsAssignableFrom(t))
                                           where !x.IsAbstract && !x.IsInterface
                                           select x).ToList();
            foreach (var type in allEntityClasses)
            {
                var genericType = typeof(BaseGeneric<>).MakeGenericType(type);
                var helper = new DelegateHelper();
                var myLambda = helper.GetLambdaForType(type);
                var allInst = genericType.GetProperty("AllInstances").GetValue(null);
                if (allInst == null)
                {
                    allInst = Activator.CreateInstance(genericType.GetProperty("AllInstances").PropertyType);
                }
                allInst.GetType().GetProperty("FindAll").SetValue(allInst,myLambda);
            }
        }
         
    }
    public static class BaseGeneric<T>
    {
        public static AllInstances<T> AllInstances { get; set; }
    }
    public class AllInstances<T>
    {
        public Func<T[]> FindAll { get; set; }
    }
    public class DelegateHelper
    {
        public Delegate GetLambdaForType(Type type)
        {
            var funcType = typeof(Func<>).MakeGenericType(type.MakeArrayType());
            var methodInfo = typeof(DelegateHelper).GetMethods().FirstOrDefault(t => t.Name == "FunctionMethod")
                                                   .MakeGenericMethod(type);
            var @delegate = methodInfo.CreateDelegate(funcType, this);
            return @delegate;
        }
        public T[] FunctionMethod<T>()
        {   
            return new T[10];
        }
    }
    public  class Entity
    {
    }
    public class EntityFirst
    {
        
    }
    public class EntitySecond
    {
    }

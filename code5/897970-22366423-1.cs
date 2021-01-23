    class Program
    {
      static void Main(string[] args)
      {
        Assembly asm = Assembly.GetExecutingAssembly();
        Type[] types = asm.GetTypes();
    
        foreach (var type in types)
        {
          if (type.IsSubclassOf(typeof(MonoBehavior)) || type.GetInterfaces().Contains(typeof(MonoBehavior)))
          {
            MethodInfo startMethod = type.GetMethod("Start", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            if (startMethod != null)
            {
              ConstructorInfo ctor = type.GetConstructor(new Type[] { });
              if (ctor != null)
              {
                object inst = ctor.Invoke(new object[] { });
                startMethod.Invoke(inst, new object[] { });
              }
            }
          }
        }
      }
    }
    
    interface MonoBehavior
    {
    }
    
    class Example1 : MonoBehavior
    {
      static void Start()
      {
        Console.WriteLine("Example1 Start");
      }
    }
    
    class Example2 : MonoBehavior
    {
    }

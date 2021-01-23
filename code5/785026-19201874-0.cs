    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    namespace ConsoleApplication2
    {
        // Start by declaring a delegate that looks exactly like the library method you want to call, but with TRuntimeType in place of the actual type
        public delegate void LibraryDelegate<TRuntimeType>(TRuntimeType param, Int32 num, String aStr);
        // Declare an "adapter" delegate that uses "Object" in place of TRuntimeType for every relevant parameter
        public delegate void AdapterDelegate(Object param, Int32 num, String aStr);
        public static class AdapterDelegateHelper
        {
            private class Adapter<TRuntimeType>
            {
                private readonly LibraryDelegate<TRuntimeType> libDelegate;
            
                public Adapter(Object LibraryInstance, String MethodName)
                {
                    Type libraryType = LibraryInstance.GetType();
                    Type[] methodParameters = typeof(LibraryDelegate<TRuntimeType>).GetMethod("Invoke").GetParameters().Select(p => p.ParameterType).ToArray();
                    MethodInfo libMethod = libraryType.GetMethod(MethodName, methodParameters);
                    libDelegate = (LibraryDelegate<TRuntimeType>) Delegate.CreateDelegate(typeof(LibraryDelegate<TRuntimeType>), LibraryInstance, libMethod);
                }
            
                // Method that pricecly matches the adapter delegate
                public void adapter(Object param, Int32 num, String aStr)
                {
                    // Convert all TRuntimeType parameters.
                    // This is a true conversion!
                    TRuntimeType r_param = (TRuntimeType)param;
                    // Call the library delegate.
                    libDelegate(r_param, num, aStr);
                }
            }
        
            public static AdapterDelegate MakeAdapter(Object LibraryInstance, String MethodName, Type runtimeType)
            {
                Type genericType = typeof(Adapter<>);
                Type concreteType = genericType.MakeGenericType(new Type[] { runtimeType });
                Object obj = Activator.CreateInstance(concreteType, LibraryInstance, MethodName);
                return (AdapterDelegate)Delegate.CreateDelegate(typeof(AdapterDelegate), obj, concreteType.GetMethod("adapter"));
            }
        }
    
        // This class emulates a runtime-identified type; I'll only use it through reflection
        class LibraryClassThatIOnlyKnowAboutAtRuntime
        {
            // Define a number of oberloaded methods to prove proper overload selection
            public void DoSomething(String param, Int32 num, String aStr)
            {
                Console.WriteLine("This is the DoSomething overload that takes String as a parameter");
                Console.WriteLine("param={0}, num={1}, aStr={2}", param, num, aStr);
            }
            public void DoSomething(Int32 param, Int32 num, String aStr)
            {
                Console.WriteLine("This is the DoSomething overload that takes Integer as a parameter");
                Console.WriteLine("param={0}, num={1}, aStr={2}", param, num, aStr);
            }
            // This would be the bad delegate to avoid!
            public void DoSomething(Object param, Int32 num, String aStr)
            {
                throw new Exception("Do not call this method!");
            }
        }
    
        class Program
        {
        
            static void Main(string[] args)
            {
                Type castToType = typeof(string);
                Type libraryTypeToCall = typeof(LibraryClassThatIOnlyKnowAboutAtRuntime);
                Object obj = Activator.CreateInstance(libraryTypeToCall);
                AdapterDelegate ad1 = AdapterDelegateHelper.MakeAdapter(obj, "DoSomething", castToType);
                ad1("param", 7, "aStr");
            
                Console.ReadKey();
            }
        }
    }

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    
    namespace ConsoleApplication17
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyProxy<IFoo> proxy = new MyProxy<IFoo>(new Foo());
    
                IFoo proxiedFoo = (IFoo)proxy.GetTransparentProxy();
    
                // make a proxied call...
                proxiedFoo.DoSomething();
    
                // cast proxiedFoo to IDisposable and dispose of it...
                IDisposable disposableFoo = proxiedFoo as IDisposable;
    
                // disposableFoo is null at this point.
    
                disposableFoo.Dispose();
            }
        }
    
        public interface IFoo
        {
            void DoSomething();
        }
    
        public class Foo : IFoo, IDisposable
        {
            #region IFoo Members
    
            public void DoSomething()
            {
                Console.WriteLine("DoSomething called!");
            }
    
            #endregion
    
            #region IDisposable Members
    
            public void Dispose()
            {
                // dispose
                Console.WriteLine("Disposing Foo!");
            }
    
            #endregion
        }
    
        public class MyProxy<T> : RealProxy where T : class
        {
            private T _target;
    
            public MyProxy(T target) :
                base(CombineType(typeof(T), typeof(IDisposable)))
            {
                this._target = target;
            }
    
            private static Type CombineType(Type type1, Type type2)
            {
                // How to implement this method, Reflection.Emit????
                return DynamicInterfaceFactory.GenerateCombinedInterfaceType(type1, type2);
            }
    
            public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
            {
                return InvokeRemoteCall((IMethodCallMessage)msg, this._target);
            }
    
            /// <summary>
            /// Invokes the remote call.
            /// </summary>
            /// <param name="methodCall">The method call.</param>
            /// <param name="target">The target.</param>
            /// <returns>A <see cref="ReturnMessage"/></returns>
            private static IMessage InvokeRemoteCall(IMethodCallMessage methodCall, object target)
            {
                MethodInfo method = methodCall.MethodBase as MethodInfo;
    
                object callResult = (target != null) ? method.Invoke(target, methodCall.InArgs) : null;
    
                LogicalCallContext context = methodCall.LogicalCallContext;
    
                var query = method.GetParameters().Where(param => ((ParameterInfo)param).IsOut);
    
                ParameterInfo[] outParameters = query.ToArray();
    
                return new ReturnMessage(callResult, outParameters, outParameters.Count(), context, methodCall);
            }
        }
    
        public static class DynamicInterfaceFactory
        {
            public static Type GenerateCombinedInterfaceType(Type type1, Type type2)
            {            
                if (!type1.IsInterface)
                    throw new ArgumentException("Type type1 is not an interface", "type1");
    
                if (!type2.IsInterface)
                    throw new ArgumentException("Type type2 is not an interface", "type2");
    
                //////////////////////////////////////////////
                // Module and Assembly Creation
    
                var orginalAssemblyName = type1.Assembly.GetName().Name;
    
                ModuleBuilder moduleBuilder;
    
                var tempAssemblyName = new AssemblyName(Guid.NewGuid().ToString());
    
                var dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    tempAssemblyName,
                    System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
    
                moduleBuilder = dynamicAssembly.DefineDynamicModule(
                    tempAssemblyName.Name,
                    tempAssemblyName + ".dll");
    
    
                var assemblyName = moduleBuilder.Assembly.GetName();
    
                //////////////////////////////////////////////
    
                //////////////////////////////////////////////
                // Create the TypeBuilder
    
                var typeBuilder = moduleBuilder.DefineType(
                    type1.FullName,
                    TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract);
    
                typeBuilder.AddInterfaceImplementation(type1);
                typeBuilder.AddInterfaceImplementation(type2);
    
                //////////////////////////////////////////////
    
                //////////////////////////////////////////////
                // Create and return the defined type
    
                Type newType = typeBuilder.CreateType();
    
                return newType;
    
                //////////////////////////////////////////////
            }
        }
    }

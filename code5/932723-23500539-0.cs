    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    
    namespace HelloWorld
    {
        public class Service1
        {
            public Task ServiceMethod(string something)
            {
                return Task.Factory.StartNew(() => Console.WriteLine(something));
            }
        }
    
        public class HubServiceInvoker<T> where T : new()
        {
            T t;
    
            public HubServiceInvoker(string id, string password)
            {
                t = new T();
            }
    
            public void InvokeService(Func<T, Task> serviceInvoker)
            {
                Task task = serviceInvoker(t);
            }
    
            public static Func<T, Task> CompileInvoker(Expression expression, ParameterExpression serviceTParam)
            {
                Expression<Func<T, Task>> lambda = Expression.Lambda<Func<T, Task>>(expression, serviceTParam);
                return lambda.Compile();
            }
        }
    
        public class WorkOutMessage
        {
            public string interfaceType { get; set; }
            public string[] methodArgTypes { get; set; }
            public object[] methodArgs { get; set; }
            public string methodName { get; set; }
        }
    
        static class Program
        {
            static void Main(string[] args)
            {
                WorkOutMessage workOutMessage = new WorkOutMessage()
                {
                    interfaceType = "HelloWorld.Service1",
                    methodArgTypes = new string[] { "System.String" },
                    methodArgs = new object[] { "yeah it works!" },
                    methodName = "ServiceMethod"
                };
    
                InvokeService(workOutMessage);
    
                Console.Read();
            }
    
            static void InvokeService(WorkOutMessage workOutMessage)
            {
                // Types
                var serviceT = Type.GetType(workOutMessage.interfaceType);
    
                // ServiceInvoker<T> Instantiation - Works
                var serviceInvokerT = typeof(HubServiceInvoker<>).MakeGenericType(serviceT);
                var serviceInvokerTMethod = serviceInvokerT.GetMethod("InvokeService");
                var serviceCompileInvokerTMethod = serviceInvokerT.GetMethod("CompileInvoker");
                var serviceInvokerTInstance = Activator.CreateInstance(serviceInvokerT, "id", "password");
    
                // Expression Type Params
                var serviceTParam = Expression.Parameter(serviceT, "proxy");
    
                var methodCall = Expression.Call(serviceTParam, serviceT.GetMethod(workOutMessage.methodName), Expression.Constant(workOutMessage.methodArgs[0]));
    
                serviceInvokerTMethod.Invoke(serviceInvokerTInstance, new object[] { 
                    serviceCompileInvokerTMethod.Invoke(serviceInvokerTInstance, new object[] { methodCall, serviceTParam })
                });
            }
        }
    }

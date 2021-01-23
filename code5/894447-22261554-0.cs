    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    using System.Text;
    
    namespace ConsoleApplication27
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo foo = new Foo(){ Name = "My Foo1" };
    
                Console.WriteLine(foo.Name);
    
                FooProxy fooProxy = new FooProxy(foo);
    
                Foo proxiedFoo = (Foo)fooProxy.GetTransparentProxy();
    
                Console.WriteLine(proxiedFoo.Name);
            }
        }
    
        public class Foo : MarshalByRefObject
        {
            public string Name { get; set; }
        }
    
        public class FooProxy 
            : RealProxy
        {
            private Foo _target;
    
            public FooProxy(Foo target) : base(typeof(Foo))
            {
                this._target = target;
            }
    
            public override IMessage Invoke(IMessage msg)
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
    }

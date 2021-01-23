    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    public static class AutomaticFactoryExtensions {
        public static void RegisterFactory<TFactory>(this Container container) {
            if (!typeof(TFactory).IsInterface)
                throw new ArgumentException(typeof(TFactory).Name + " is no interface");
            container.ResolveUnregisteredType += (s, e) => {
                if (e.UnregisteredServiceType == typeof(TFactory)) {
                    e.Register(Expression.Constant(
                        value: CreateFactory(typeof(TFactory), container),
                        type: typeof(TFactory)));
                }
            };
        }
        public static object CreateFactory(Type factoryType, Container container) {
            var proxy = new AutomaticFactoryProxy(factoryType, container);
            return proxy.GetTransparentProxy();
        }
        private sealed class AutomaticFactoryProxy : RealProxy {
            private readonly Type factoryType;
            private readonly Container container;
            public AutomaticFactoryProxy(Type factoryType, Container container)
                : base(factoryType) {
                this.factoryType = factoryType;
                this.container = container;
            }
            public override IMessage Invoke(IMessage msg) {
                if (msg is IMethodCallMessage) {
                    return this.InvokeFactory(msg as IMethodCallMessage);
                }
                return msg;
            }
            private IMessage InvokeFactory(IMethodCallMessage msg) {
                if (msg.MethodName == "GetType")
                    return new ReturnMessage(this.factoryType, null, 0, null, msg);
                if (msg.MethodName == "ToString")
                    return new ReturnMessage(this.factoryType.Name, null, 0, null, msg);
                
                var method = (MethodInfo)msg.MethodBase;
                object instance = this.container.GetInstance(method.ReturnType);
                return new ReturnMessage(instance, null, 0, null, msg);
            }
        }
    }

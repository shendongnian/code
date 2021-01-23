    public interface IDefaultValueFactory
    {
        T GetDefault<T>();
    }
    public static class NSubstituteDefaultValueConfigurator
    {
        public static void Configure(Type substituteType, object substitute, IDefaultValueFactory valueFactory)
        {
            var type = typeof(NSubstituteDefaultValueConfigurator<>)
                .MakeGenericType(substituteType);
            var configurator = type
                .GetConstructor(new Type[] { typeof(IDefaultValueFactory) })
                .Invoke(new object[] { valueFactory });
            type.GetMethod("ConfigureDefaultReturnValuesForAllMethods")
                .Invoke(configurator, new object[] { substitute });
        }
    }
    public class NSubstituteDefaultValueConfigurator<T>
    {
        private readonly IDefaultValueFactory _valueFactory;
        public NSubstituteDefaultValueConfigurator(IDefaultValueFactory valueFactory)
        {
            _valueFactory = valueFactory;
        }
        private object GetDeafultValue<TResult>()
        {
            return _valueFactory.GetDefault<TResult>();
        }
        public void ConfigureDefaultReturnValuesForAllMethods(T substitute)
        {
            var interfaces = substitute
                .GetType()
                .GetInterfaces()
                // HACK: Specifically exclude supporting interfaces from NSubstitute
                .Where(i =>
                    i != typeof(Castle.DynamicProxy.IProxyTargetAccessor) &&
                    i != typeof(ICallRouter) /*&&
                    i != typeof(ISerializable)*/)
                .ToArray();
            var methods = interfaces
                .SelectMany(i => i.GetMethods())
                .Where(m => m.ReturnType != typeof(void))
                // BUG: skipping over chained interfaces in NSubstitute seems
                // to cause an issue with embedded returns. Using them however
                // causes the mock at the end or along a chained call not to be
                // configured for default values.
                .Where(m => !m.ReturnType.IsInterface);
            foreach (var method in methods)
            {
                var typedConfigureMethod = this
                    .GetType()
                    .GetMethod("ConfigureDefaultReturnValuesForMethod", BindingFlags.NonPublic | BindingFlags.Static)
                    .MakeGenericMethod(method.ReturnType);
                var defaultValueFactory = new Func<CallInfo, object>(
                    callInfo => this
                        .GetType()
                        .GetMethod("GetDeafultValue", BindingFlags.NonPublic | BindingFlags.Instance)
                        .MakeGenericMethod(method.ReturnType)
                        .Invoke(this, null));
                typedConfigureMethod.Invoke(
                    this,
                    new object[]
                        {
                            substitute, 
                            defaultValueFactory,
                            method
                        });
            }
            //var properties = interfaces.SelectMany(i => i.GetProperties());
            var properties = substitute
                .GetType().GetProperties();
            foreach (var property in properties)
            {
                var typedConfigureMethod = this
                    .GetType()
                    .GetMethod("ConfigureDefaultReturnValuesForProperty", BindingFlags.NonPublic | BindingFlags.Static)
                    .MakeGenericMethod(property.PropertyType);
                var defaultValueFactory = new Func<CallInfo, object>(
                    callInfo => this
                        .GetType()
                        .GetMethod("GetDeafultValue", BindingFlags.NonPublic | BindingFlags.Instance)
                        .MakeGenericMethod(property.PropertyType)
                        .Invoke(this, null));
                typedConfigureMethod.Invoke(
                    this,
                    new object[]
                        {
                            substitute, 
                            defaultValueFactory,
                            property
                        });
            }
        }
        private static void ConfigureDefaultReturnValuesForMethod<TResult>(
            T substitute,
            Func<CallInfo, object> defaultValueFactory,
            MethodInfo method)
        {
            var args = method
                .GetParameters()
                .Select(p => GetTypedAnyArg(p.ParameterType))
                .ToArray();
            // Call the method on the mock
            var substituteResult = method.Invoke(substitute, args);
            var returnsMethod = typeof(SubstituteExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .First(m => m.GetParameters().Count() == 2)
                .MakeGenericMethod(method.ReturnType);
            var typedDefaultValueFactory = new Func<CallInfo, TResult>(callInfo => (TResult)defaultValueFactory(callInfo));
            returnsMethod.Invoke(null, new[] { substituteResult, typedDefaultValueFactory });
        }
        private static void ConfigureDefaultReturnValuesForProperty<TResult>(
            T substitute,
            Func<CallInfo, object> defaultValueFactory,
            PropertyInfo property)
        {
            // Call the property getter on the mock
            var substituteResult = property.GetGetMethod().Invoke(substitute, null);
            
            var returnsMethod = typeof(SubstituteExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .First(m => m.GetParameters().Count() == 2)
                .MakeGenericMethod(property.PropertyType);
            var typedDefaultValueFactory = new Func<CallInfo, TResult>(callInfo => (TResult)defaultValueFactory(callInfo));
            returnsMethod.Invoke(null, new[] { substituteResult, typedDefaultValueFactory });
        }
        private static object GetTypedAnyArg(Type argType)
        {
            return GetStaticGenericMethod(typeof(Arg), "Any", argType);
        }
        private static MethodInfo GetStaticGenericMethod(
            Type classType,
            string methodName,
            params Type[] typeParameters)
        {
            var method = classType
                .GetMethod(methodName, BindingFlags.Static | BindingFlags.Public)
                .MakeGenericMethod(typeParameters);
            return method;
        }
    }

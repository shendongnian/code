    public static class ContainerExtensions
    {
        public static InjectionBuilder<TFrom, TTo> BuildInjections<TFrom, TTo>(this IUnityContainer container)
            where TTo : TFrom
        {
            return new InjectionBuilder<TFrom, TTo>(container);
        }
        public static MemberInfo GetMemberInfo(this Expression expression)
        {
            var lambda = (LambdaExpression)expression;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
                memberExpression = (MemberExpression)lambda.Body;
            return memberExpression.Member;
        }
    }
    // This class is the fluent API
    public class InjectionBuilder<TFrom, TTo>
        where TTo : TFrom
    {
        private readonly IList<InjectionMember> _injectionMembers = new List<InjectionMember>();
        private readonly IUnityContainer _container;
        public InjectionBuilder(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }
        
        public InjectionBuilder<TFrom, TTo> AddPropertyInjection<TType>(Expression<Func<TFrom, TType>> property,
                                                                        TType value)
        {
            var propName = property.GetMemberInfo().Name;
            _injectionMembers.Add(new InjectionProperty(propName, value));
            return this;
        }
        public IUnityContainer Register()
        {
            return _container.RegisterType<TFrom, TTo>(_injectionMembers.ToArray());
        }
    }

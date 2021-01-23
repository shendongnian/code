    [DebuggerDisplay("DependencyContext (ServiceType: {ServiceType}, " + 
        "ImplementationType: {ImplementationType})")]
    public class DependencyContext {
        internal static readonly DependencyContext Root = 
            new DependencyContext();
        internal DependencyContext(Type serviceType, 
            Type implementationType, DependencyContext parent)
        {
            this.ServiceType = serviceType;
            this.ImplementationType = implementationType;
            this.Parent = parent;
        }
        private DependencyContext() { }
        // There's now a Parent property!
        public DependencyContext Parent { get; private set; }
        public Type ServiceType { get; private set; }
        public Type ImplementationType { get; private set; }
    }
    public static class ContextDependentExtensions {
        public static void RegisterWithContext<TService>(
            this Container container,
            Func<DependencyContext, TService> contextBasedFactory)
            where TService : class {
            if (contextBasedFactory == null) {
                throw new ArgumentNullException("contextBasedFactory");
            }
            Func<TService> rootFactory = 
                () => contextBasedFactory(DependencyContext.Root);
            container.Register<TService>(rootFactory, Lifestyle.Transient);
            // Allow the Func<DependencyContext, TService> to be 
            // injected into parent types.
            container.ExpressionBuilding += (sender, e) => {
                if (e.RegisteredServiceType != typeof(TService)) {
                    var rewriter = new DependencyContextRewriter {
                        ServiceType = e.RegisteredServiceType,
                        ContextBasedFactory = contextBasedFactory,
                        RootFactory = rootFactory,
                        Expression = e.Expression
                    };
                    e.Expression = rewriter.Visit(e.Expression);
                }
            };
        }
        private sealed class DependencyContextRewriter : ExpressionVisitor {
            internal Type ServiceType { get; set; }
            internal object ContextBasedFactory { get; set; }
            internal object RootFactory { get; set; }
            internal Expression Expression { get; set; }
            internal Type ImplementationType
            {
                get {
                    var expression = this.Expression as NewExpression;
                    if (expression != null) {
                        return expression.Constructor.DeclaringType;
                    }
                    return this.ServiceType;
                }
            }
            protected override Expression VisitInvocation(InvocationExpression node) {
                var context = GetContextFromNode(node);
                if (context == null) {
                    return base.VisitInvocation(node);
                }
                return Expression.Invoke(
                    Expression.Constant(this.ContextBasedFactory),
                    Expression.Constant(
                        new DependencyContext(
                            this.ServiceType,
                            this.ImplementationType,
                            context)));
            }
            private DependencyContext GetContextFromNode(InvocationExpression node) {
                var constant = node.Expression as ConstantExpression;
                if (constant != null) {
                    if (object.ReferenceEquals(constant.Value, this.RootFactory)) {
                        return DependencyContext.Root;
                    }
                
                    if (object.ReferenceEquals(constant.Value, this.ContextBasedFactory)) {
                        var arg = (ConstantExpression)node.Arguments[0];
                        return (DependencyContext)(arg.Value);
                    }
                }
                return null;
            }
        }
    }

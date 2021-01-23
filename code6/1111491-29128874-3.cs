    // v0.1 Codename: Handle with Care
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class ExpandableAttribute : Attribute
    {
        // Just to know the suffix to use :-)
        public static readonly string ExpandableSuffix = "Expression";
    }
    // Replaces method and properties calls to "special" method calls that 
    // are Expression(s). These method/property calls can be used anywhere in 
    // the query (Select, Where, GroupBy, ...)
    // Remember to use .AsExpandable2() somewhere in your query (it must be a 
    // "top level" part of the query):
    // OK:
    // var res1 = (from x in table select x).AsExpandable();
    // var res2 = table.AsExpandable().Where(x => true);
    // var res3 = table.Where(x => true).AsExpandable();
    // var res4 = table.Where(x => true).AsExpandable().Select(x => x);
    // var res5 = table.Where(x => true).AsExpandable().Select(x => x).AsExpandable();
    // Not OK:
    // var res1 = table.Select(x => x.subtable.AsExpandable());
    // **Method calls**
    // The methods to be expanded can be static or instance. There must be
    // a corresponding **static* method with same name and suffix 
    // "Expression", that doesn't have parameters and returns an Expression 
    // with a certain signature.
    // Static:
    // var res2 = table.AsExpandable().Select(x => MyClass.StaticMethod(1, x, 2, 3));
    // There must be in the class MyClass
    // public/private/protected static Expression<Func<int, MyClass, int, int, returnType(StaticMethod)>> StaticMethodExpression()
    // Instance:
    // var res1 = table.AsExpandable().Select(x => x.InstanceMethod(1, 2, 3));
    // There must be in the class x.GetType() 
    // public/private/protected static Expression<Func<x.GetType(), int, int, int, returnType(InstanceMethod)>> InstanceMethodExpression()
    // Note that multiple "tables" can be passed as parameters:
    // Static:
    // var res3 = (from x in table1 from y in table2 select new { x, y }).AsExpandable().Select(z => MyClass.StaticMethod(1, z.x, z.y, 2, 3));
    // There must be in the class MyClass
    // public/private/protected/internal static Expression<Func<int, x.GetType(), y.GetType(), int, int, returnType(StaticMethod)>> StaticMethodExpression()
    // Instance:
    // var res4 = (from x in table1 from y in table2 select new { x, y }).AsExpandable().Select(z => z.x.StaticMethod(1, z.y, 2, 3));
    // There must be in the class x.GetType() 
    // public/private/protected/internal static Expression<Func<x.GetType(), int, y.GetType(), int, int, returnType(StaticMethod)>> InstanceMethodExpression()
    // **Properties**
    // Same as with method calls, but with properties :-)
    // (useful for things like FullName, where 
    // FullName = Name + ' ' + Surname)
    // Remember that the *Expression property must be **static**!
    // Static (not very useful :-) ):
    // var res1 = table.AsExpandable().Select(x => MyClass.StaticProperty);
    // There must be in the class MyClass
    // public/private/protected/internal static Expression<Func<MyClass.StaticProperty.GetType()>> StaticPropertyExpression { get; }
    // Instance:
    // var res2 = table.AsExpandable().Select(x => x.InstanceProperty);
    // There must be in the class x.GetType() 
    // public/private/protected/internal static Expression<Func<x.GetType(), x.InstanceProperty.GetType())>> InstancePropertyExpression { get; }
    public static class MethodsPropertiesExpander
    {
        // Because AsExpandable is already used by http://www.albahari.com/nutshell/linqkit.aspx
        public static IQueryable<T> AsExpandable2<T>(this IQueryable<T> source)
        {
            if (source is MethodsPropertiesExpander<T>)
            {
                return source;
            }
            return new MethodsPropertiesExpander<T>(source);
        }
    }
    public interface IMethodsPropertiesExpander
    {
    }
    public class MethodsPropertiesExpander<T> : IOrderedQueryable<T>, IQueryProvider, IMethodsPropertiesExpander
    {
        public readonly IQueryable<T> Query;
        public MethodsPropertiesExpander(IQueryable<T> query)
        {
            if (!(query is IMethodsPropertiesExpander))
            {
                Expression expression = MethodsPropertiesReplacer.Default.Visit(query.Expression);
                Query = expression == query.Expression ? query : query.Provider.CreateQuery<T>(expression);
            }
            else
            {
                Query = query;
            }
        }
        /* IQueryable<T> */
        public IEnumerator<T> GetEnumerator()
        {
            return Query.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return Query.ElementType; }
        }
        public Expression Expression
        {
            get { return Query.Expression; }
        }
        public IQueryProvider Provider
        {
            get { return this; }
        }
        /* IQueryProvider */
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new MethodsPropertiesExpander<TElement>(Query.Provider.CreateQuery<TElement>(expression));
        }
        public IQueryable CreateQuery(Expression expression)
        {
            Type iqueryableArgument = GetIQueryableTypeArgument(expression.Type);
            MethodInfo createQueryImplMethod = typeof(MethodsPropertiesExpander<T>)
                .GetMethod("CreateQuery", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(iqueryableArgument);
            return (IQueryable)createQueryImplMethod.Invoke(this, new[] { expression });
        }
        public TResult Execute<TResult>(Expression expression)
        {
            if (!(Query.Provider is IMethodsPropertiesExpander))
            {
                // We want to expand it only once :-)
                expression = MethodsPropertiesReplacer.Default.Visit(expression);
            }
            return Query.Provider.Execute<TResult>(expression);
        }
        public object Execute(Expression expression)
        {
            if (!(Query.Provider is IMethodsPropertiesExpander))
            {
                // We want to expand it only once :-)
                expression = MethodsPropertiesReplacer.Default.Visit(expression);
            }
            return Query.Provider.Execute(expression);
        }
        /* Implementation methods */
        /// <summary>
        /// Gets the T of IQueryablelt;T&gt;
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static Type GetIQueryableTypeArgument(Type type)
        {
            IEnumerable<Type> interfaces = type.IsInterface ?
                new[] { type }.Concat(type.GetInterfaces()) :
                type.GetInterfaces();
            Type argument = (from x in interfaces
                             where x.IsGenericType
                             let gt = x.GetGenericTypeDefinition()
                             where gt == typeof(IQueryable<>)
                             select x.GetGenericArguments()[0]).FirstOrDefault();
            return argument;
        }
        /* Utility classes */
        protected sealed class MethodsPropertiesReplacer : ExpressionVisitor
        {
            // Single instance is enough!
            public static readonly MethodsPropertiesReplacer Default = new MethodsPropertiesReplacer();
            private MethodsPropertiesReplacer()
            {
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                PropertyInfo property = node.Member as PropertyInfo;
                MethodInfo getter;
                // We handle only properties (that aren't indexers) that have 
                // a get
                if (property != null && property.GetIndexParameters().Length == 0 && (getter = property.GetGetMethod(true)) != null)
                {
                    // We work only on methods marked as [ExpandableAttribute]
                    var attribute = property.GetCustomAttribute(typeof(ExpandableAttribute));
                    if (attribute != null)
                    {
                        string name = property.Name + ExpandableAttribute.ExpandableSuffix;
                        var property2 = property.DeclaringType.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, null, Type.EmptyTypes, null);
                        if (property2 == null || property2.GetGetMethod(true) == null)
                        {
                            if (property2 == null)
                            {
                                if (property.DeclaringType.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, Type.EmptyTypes, null) != null)
                                {
                                    throw new NotSupportedException(string.Format("{0}.{1} isn't static!", property.DeclaringType.FullName, name));
                                }
                                throw new NotSupportedException(string.Format("{0}.{1} not found!", property.DeclaringType.FullName, name));
                            }
                            // property2.GetGetMethod(true) == null
                            throw new NotSupportedException(string.Format("{0}.{1} doesn't have a getter!", property.DeclaringType.FullName, name));
                        }
                        // Instance Parameters have the additional 
                        // "parameter" of the declaring type
                        var argumentsPlusReturnTypes = getter.IsStatic ?
                            new[] { node.Type } :
                            new[] { property.DeclaringType, node.Type };
                        var funcType = typeof(Func<>).Assembly.GetType(string.Format("System.Func`{0}", argumentsPlusReturnTypes.Length));
                        var returnType = typeof(Expression<>).MakeGenericType(funcType.MakeGenericType(argumentsPlusReturnTypes));
                        if (property2.PropertyType != returnType)
                        {
                            throw new NotSupportedException(string.Format("{0}.{1} has wrong return type!", property.DeclaringType.FullName, name));
                        }
                        var expression = (LambdaExpression)property2.GetValue(null);
                        // Instance Members have the additional "parameter" 
                        // of the declaring type
                        var arguments2 = getter.IsStatic ? new Expression[0] : new[] { node.Expression };
                        var replacer = new ParametersReplacer(expression.Parameters, arguments2);
                        var body = replacer.Visit(expression.Body);
                        return this.Visit(body);
                    }
                }
                return base.VisitMember(node);
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                MethodInfo method = node.Method;
                // We work only on methods marked as [ExpandableAttribute]
                var attribute = method.GetCustomAttribute(typeof(ExpandableAttribute));
                if (attribute != null)
                {
                    string name = method.Name + ExpandableAttribute.ExpandableSuffix;
                    var method2 = method.DeclaringType.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                    if (method2 == null)
                    {
                        if (method.DeclaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null) != null)
                        {
                            throw new NotSupportedException(string.Format("{0}.{1} isn't static!", method.DeclaringType.FullName, name));
                        }
                        throw new NotSupportedException(string.Format("{0}.{1} not found!", method.DeclaringType.FullName, name));
                    }
                    // Instance methods have the additional "parameter" of
                    // the declaring type
                    var argumentsPlusReturnTypes = method.IsStatic ?
                        node.Arguments.Select(x => x.Type).Concat(new[] { node.Type }).ToArray() :
                        new[] { method.DeclaringType }.Concat(node.Arguments.Select(x => x.Type)).Concat(new[] { node.Type }).ToArray();
                    var funcType = typeof(Func<>).Assembly.GetType(string.Format("System.Func`{0}", argumentsPlusReturnTypes.Length));
                    var returnType = typeof(Expression<>).MakeGenericType(funcType.MakeGenericType(argumentsPlusReturnTypes));
                    if (method2.ReturnType != returnType)
                    {
                        throw new NotSupportedException(string.Format("{0}.{1} has wrong return type!", method.DeclaringType.FullName, name));
                    }
                    var expression = (LambdaExpression)method2.Invoke(null, null);
                    // Instance methods have the additional "parameter" of
                    // the declaring type
                    var arguments2 = method.IsStatic ? node.Arguments : new[] { node.Object }.Concat(node.Arguments);
                    var replacer = new ParametersReplacer(expression.Parameters, arguments2);
                    var body = replacer.Visit(expression.Body);
                    return this.Visit(body);
                }
                return base.VisitMethodCall(node);
            }
        }
        // Simple ParameterExpression replacer
        protected class ParametersReplacer : ExpressionVisitor
        {
            public readonly Dictionary<ParameterExpression, Expression> FromTo = new Dictionary<ParameterExpression, Expression>();
            public ParametersReplacer(IEnumerable<ParameterExpression> from, IEnumerable<Expression> to)
            {
                using (var enu1 = from.GetEnumerator())
                using (var enu2 = to.GetEnumerator())
                {
                    while (true)
                    {
                        bool res1 = enu1.MoveNext();
                        bool res2 = enu2.MoveNext();
                        if (!res1 || !res2)
                        {
                            if (!res1 && !res2)
                            {
                                break;
                            }
                            if (!res1)
                            {
                                throw new ArgumentException("from shorter");
                            }
                            throw new ArgumentException("to shorter");
                        }
                        FromTo.Add(enu1.Current, enu2.Current);
                    }
                }
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression to;
                if (FromTo.TryGetValue(node, out to))
                {
                    return this.Visit(to);
                }
                return base.VisitParameter(node);
            }
        }
    }

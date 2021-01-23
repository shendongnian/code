    using System;
    using System.Linq.Expressions;
    
    namespace TestApp
    {
        public class Class1
        {
            public static void Main()
            {
                object lazyInt = ResolveTest(typeof(Lazy<int>));
                Console.WriteLine(lazyInt.GetType() == typeof(Lazy<int>));
                Console.WriteLine(((Lazy<int>)lazyInt).Value);
            }
    
            static readonly Type _lazyType = typeof(Lazy<>);
            static Object ResolveTest(Type type)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == _lazyType)
                {
                    var arg = type.GetGenericArguments()[0];
                    var lazyArgType = _lazyType.MakeGenericType(arg);
                    var funcArgType = typeof(Func<>).MakeGenericType(arg);
                    var funcCtor = lazyArgType.GetConstructor(new[] { funcArgType });
                    Expression<Func<object>> f = () => ResolveTest(arg);
                    var func = typeof(Class1).GetMethod("BuildCastedThing").MakeGenericMethod(arg).Invoke(null, new[] { f });
                    var arguments = new object[] { func };
    
                    var retVal = funcCtor.Invoke(arguments);
                    return retVal;
                }
                else
                    return ResolveType(type);
            }
            public static object ResolveType(Type type)
            {
                return Activator.CreateInstance(type);
            }
            public static Func<T> BuildCastedThing<T>(Expression<Func<object>> f)
            {
                Expression<Func<T>> expr =
                    Expression.Lambda<Func<T>>(
                        Expression.Convert(
                            Expression.Invoke(f),
                            typeof(T)));
    
                return expr.Compile();
            }
        }
    }

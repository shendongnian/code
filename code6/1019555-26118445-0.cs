    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    static class Program
    {
        static void Main()
        {
            bool x = MyHelper.AnyNull(new Foo { }); // true
            bool y = MyHelper.AnyNull(new Foo { X = "" }); // false
        }
    }
    class Foo
    {
        public string X { get; set; }
        public int Y { get; set; }
    }
    static class MyHelper
    {
        public static bool AnyNull<T>(T obj)
        {
            return Cache<T>.AnyNull(obj);
        }
        static class Cache<T>
        {
            public static readonly Func<T, bool> AnyNull;
    
            static Cache()
            {
                var props = typeof(T).GetProperties(
                    BindingFlags.Instance | BindingFlags.Public);
    
                var param = Expression.Parameter(typeof(T), "obj");
                Expression body = null;
    
                foreach(var prop in props)
                {
                    if (!prop.CanRead) continue;
    
                    if(prop.PropertyType.IsValueType)
                    {
                        Type underlyingType = Nullable.GetUnderlyingType(
                                                  prop.PropertyType);
                        if (underlyingType == null) continue; // cannot be null
    
                        // TODO: handle Nullable<T>
                    }
                    else
                    {
                        Expression check = Expression.Equal(
                            Expression.Property(param, prop),
                            Expression.Constant(null, prop.PropertyType));
                        body = body == null ? check : Expression.OrElse(body, check);
                    }
                }
                if (body == null) AnyNull = x => false; // or true?
                else
                {
                    AnyNull = Expression.Lambda<Func<T, bool>>(body, param).Compile();
                }
            }
        }
    }

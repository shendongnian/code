    public class B
    {
    }
    static internal class Metadata<T> //Avoid lock & string metadata description
    {
        static public readonly Type Type = typeof(T);
        static public FieldInfo Field<X>(Expression<Func<T, X>> expression)
        {
            return (expression.Body as MemberExpression).Member as FieldInfo;
        }
        static public PropertyInfo Property<X>(Expression<Func<T, X>> expression)
        {
            return (expression.Body as MemberExpression).Member as PropertyInfo;
        }
        static public MethodInfo Method(Expression<Action<T>> expression)
        {
            return (expression.Body as MethodCallExpression).Method;
        }
        static public MethodInfo Method<X>(Expression<Func<T, X>> expression)
        {
            return (expression.Body as MethodCallExpression).Method;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var _Factory = new Func<object>(() => new B());
            TypeBuilder _TypeBuilder = null;// = ...;
            var _Parameters = new Type[] { Metadata<Func<object>>.Type };
            var _Constructor = _TypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, _Parameters);
            var _Body = _Constructor.GetILGenerator();
            //...
            _Body.Emit(OpCodes.Ldarg_1);
            _Body.Emit(OpCodes.Call, Metadata<Func<object>>.Method(_Func => _Func.Invoke()));
            //...
            var _Type = _TypeBuilder.CreateType();
            var _Parameter = Expression.Parameter(Metadata<Func<object>>.Type);
            var _New = Expression.Lambda<Func<Func<object>, object>>(Expression.New(_Type.GetConstructor(_Parameters), _Parameter), _Parameter).Compile();
            
            var _Instance = _New(_Factory);
        }
    }

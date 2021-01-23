    class Program
    {
        static void Main(string[] args)
        {
            var testTransform = new Transformation<string>
                {
                    Transform = s => s.ToUpper()
                };
            var a = Compile(testTransform);
            var foo = new Foo
                {
                    Value = "test"
                };
            a(foo);
            //foo.Value is now TEST
        }
        public static Action<Foo> CompileReflection(TransformationBase transformation)
        {
            var f = transformation
                .GetType()
                .GetProperty("Transform")
                .GetGetMethod()
                .Invoke(transformation, null) as Delegate;
            return foo => foo.Value = f.DynamicInvoke(foo.Value);
        }
        public static Action<Foo> Compile(TransformationBase transformation)
        {
            return new Action<Foo>(f =>
                {
                    dynamic d = f.Value;
                    dynamic t = transformation;
                    f.Value = t.Transform(d);
                });
        }
        public static Action<Foo> CompileUntyped(TransformationBase transformation)
        {
            var transformType = transformation.GetType();
            var genericType = transformType.GetGenericArguments().First();
            var fooParam = Expression.Parameter(typeof(Foo), "f");
            var valueGetter = typeof(Foo).GetProperty("Value").GetGetMethod();
            var valueSetter = typeof(Foo).GetProperty("Value").GetSetMethod();
            var transformFuncMember = transformType.GetProperty("Transform").GetGetMethod();
            //Equivalent to f => f.Value = transformation.Transform((T)f.Value)
            //Where T is the generic type parameter of the Transformation, and f is of type Foo
            var expression = Expression.Lambda<Action<Foo>>(
                Expression.Call(
                    fooParam,
                    valueSetter,
                    Expression.Invoke(
                        Expression.Property(
                            Expression.Constant(transformation, transformType), 
                            transformFuncMember
                        ),
                        Expression.Convert(
                            Expression.Property(fooParam, valueGetter),
                            genericType
                        )
                    )
                ), fooParam
            );
            return expression.Compile();
        }
    }
    public class TransformationBase { }
    public class Transformation<TProperty> : TransformationBase
    {
        public Func<TProperty, TProperty> Transform { get; set; }
    }
    public class Foo
    {
        public object Value { get; set; }
    }

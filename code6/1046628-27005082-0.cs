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
        public static Action<Foo> Compile(TransformationBase transformation)
        {
            return new Action<Foo>(f =>
                {
                    dynamic d = f.Value;
                    dynamic t = transformation;
                    f.Value = t.Transform(d);
                });
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

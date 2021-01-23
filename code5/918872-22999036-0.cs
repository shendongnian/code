    public class SomeClass
    {
        public void Method([NotNull] string Param1, [NotNull] string Param2)
        { }
    }
    public static class SomeClassExtensions
    {
        public static void InvokeWithNullCheck<TObject>(this TObject obj, Expression<Action<TObject>> expression)
        {
            var body = (MethodCallExpression)expression.Body;
            foreach(var parameter in body.Method.GetParameters())
            {
                bool hasNotNullAttribute = parameter.CustomAttributes.Any(x => x.AttributeType.Equals(typeof(NotNullAttribute)));
                if(hasNotNullAttribute && ((ConstantExpression)body.Arguments[parameter.Position]).Value == null)
                {
                    throw new ArgumentException(String.Format("Mandatory parameter {0} was not supplied.", parameter.Name));
                }
            }
            expression.Compile()(obj);
        }
    }
    [TestFixture]
    public class SomeClassTests
    {
        [Test]
        public void Test()
        {
            var test = new SomeClass();
            Assert.Throws<ArgumentException>(() => test.InvokeWithNullCheck(x => x.Method(null, "Test")));
        }
    }

    static public class Metadata<T>
    {
        static public PropertyInfo Property<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var expression = property.Body as MemberExpression;
            return expression.Member as PropertyInfo;
        }
    }
    var foo = Metadata<Test>.Property(test => test.Foo);

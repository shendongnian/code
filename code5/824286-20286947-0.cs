    class Program
    {
        static void Main()
        {
            var propertyName = Nameof<SampleClass>.Property(e => e.Name);
    
            MessageBox.Show(propertyName);
        }
    }
    
    public class GetPropertyNameOf<T>
    {
        public static string Property<TProp>(Expression<Func<T, TProp>> exp)
        {
            var body = exp.Body as MemberExpression;
            if(body == null)
                throw new ArgumentException("'exp' should be a member expression");
            return body.Member.Name;
        }
    }

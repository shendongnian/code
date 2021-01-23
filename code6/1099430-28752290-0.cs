    class Program
    {
        public static void Main()
        {
            var cls = new MyClass();
            Console.WriteLine(GetMemberInfo(cls, c => c.myInt));
            Console.ReadLine();
        }
        private static MemberInfo GetMemberInfo<TModel, TItem>(TModel model, Expression<Func<TModel, TItem>> expr)
        {
            return ((MemberExpression)expr.Body).Member;
        }
        public class MyClass
        {
            public int myInt;   
        }
        
    }

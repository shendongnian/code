    class Program
    {
        class Parent
        {
            public int A { get; set; }
            public Child Child { get; set; }
        }
        class Child
        {
            public string Data { get; set; }
        }
        public static MemberInfo GetMemberInfo(LambdaExpression exp)
        {
            var body = exp.Body as MemberExpression;
            return body.Member;
        }
        static void Main(string[] args)
        {
            Expression<Func<Parent, string>> func1 = p => p.Child.Data;
            Console.WriteLine(GetMemberInfo(func1));
            Expression<Func<Parent, int>> func2 = p => p.A;
            Console.WriteLine(GetMemberInfo(func2));
        }
    }

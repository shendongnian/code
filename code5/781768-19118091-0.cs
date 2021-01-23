    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    class Program
    {
        static void Main()
        {
            Load(new Repository<int>());
            Load(new Repository<string>());
            Console.ReadLine();
        }
        class Repository<T> { }
        static List<T> Load<T>(Repository<T> repository)
        {
            Dump(() => Load(repository));
            return default(List<T>);
        }
        static void Dump(Expression<Action> action)
        {
            var methodExpr = action.Body as MethodCallExpression;
            if (methodExpr == null)
                throw new ArgumentException();
            var methodInfo = methodExpr.Method;
            Console.WriteLine(methodInfo);
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Test
    {
        static void Main()
        {
            var type = typeof(string);
            var body = Expression.Constant(true);
            var parameter = Expression.Parameter(type);
            var delegateType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
            dynamic lambda = Expression.Lambda(delegateType, body, parameter);
            Console.WriteLine(lambda.GetType()); // Expression<string, bool>
        }
    }

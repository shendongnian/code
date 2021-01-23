    using System;
    using System.Linq.Expressions;
    
    public class Consignment
    {
        public float? Weight { get; set; }
    }    
    
    public class Test
    {        
        private static Expression NotEqual(Expression memberExpression,
                                           ConstantExpression constantToCompare)
        {
            // Other cases removed, for simplicity. This answer only demonstrates
            // how to handle c => c.Weight != 5000f.
            var hasValueExpression = Expression.Property(memberExpression, "HasValue");
            var valueExpression = Expression.Property(memberExpression, "Value");
            var notEqual = Expression.NotEqual(valueExpression, constantToCompare);
            return Expression.AndAlso(hasValueExpression, notEqual);
        }
    
        static void Main(string[] args)
        {
            Consignment consignment = new Consignment();
            consignment.Weight = 50000.0f;
            
            var parameter = Expression.Parameter(typeof(Consignment), "c");
            var weight = Expression.Property(parameter, "Weight");
            var constant = Expression.Constant(5000f, typeof(float));
            var weightNotEqualExpression = NotEqual(weight, constant);
            var lambda = Expression.Lambda<Func<Consignment, bool>>
                (weightNotEqualExpression, parameter);
            Console.WriteLine(lambda);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        public Predicate<T> GetFilterPredicate<T, R>(Expression<Func<T, R>> selector, FilterOps operand, R value)
        {
            var parameter = selector.Parameters[0];
            var left = selector.Body;
            var right = Expression.Constant(value);
            var binaryExpression = Expression.MakeBinary(operand.ToExpressionType(), left, right);
            return Expression.Lambda<Predicate<T>>(binaryExpression, parameter).Compile();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var p1 = this.GetFilterPredicate((User u) => u.Birthday.TimeOfDay.Hours, FilterOps.LessThan, 12);
            var p2 = this.GetFilterPredicate((User u) => u.Size, FilterOps.Equal, 180);
            var user = new User() { Birthday = new DateTime(2000, 1, 1), Size = 180 };
            Assert.IsTrue(p1(user));
            Assert.IsTrue(p2(user));
        }
    }
    public enum FilterOps
    {
        GreaterThan, LessThan, Equal
    }
    public static class MyExtensions
    {
        public static ExpressionType ToExpressionType(this FilterOps operand)
        {
            switch (operand)
            {
                case FilterOps.GreaterThan: return ExpressionType.GreaterThan;
                case FilterOps.LessThan: return ExpressionType.LessThan;
                case FilterOps.Equal: return ExpressionType.Equal;
                default: throw new NotSupportedException();
            }
        }
    }
    public class User { public DateTime Birthday { get; set; } public int Size { get; set; } }

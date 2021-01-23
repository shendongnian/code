    [TestClass]
    public class UnitTest1
    {
        public Predicate<T> GetFilterPredicate<T, R>(Expression<Func<T, R>> selector, MyOperand operand, R value)
        {
            var getExpressionBody = selector.Body as MemberExpression;
            var parameter = Expression.Parameter(typeof(T), "u");
            var left = Expression.Property(parameter, typeof(T).GetProperty(getExpressionBody.Member.Name));
            var right = Expression.Constant(value);
            var binaryExpression = Expression.MakeBinary(operand.ToExpressionType(), left, right);
            return Expression.Lambda<Predicate<T>>(binaryExpression, parameter).Compile();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var predicateBirthday = this.GetFilterPredicate<User, DateTime>(u => u.Birthday, MyOperand.Less, DateTime.Now);
            Assert.IsTrue(predicateBirthday(new User() { Birthday = new DateTime(2000, 1, 1) }));
            var predicateAge = this.GetFilterPredicate<User, int>(u => u.Size, MyOperand.Equal, 180);
            Assert.IsTrue(predicateAge(new User() { Size = 180 }));
        }
    }

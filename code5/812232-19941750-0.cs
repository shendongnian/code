        public static class Validate
        {
            public static void AgainstNull(string str)
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    var parametersNames = GetParameterNames(() => AgainstNull(str));
                    throw new ArgumentNullException(parametersNames[0]);
                }
            }
            private static string[] GetParameterNames(Expression<Action> expression)
            {
                var methodInfo = ((MethodCallExpression)expression.Body).Method;
                var names = methodInfo.GetParameters().Select(p => p.Name);
                return names.ToArray();
            }
        }
        [Fact]
        public void AgainstNullTest()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Validate.AgainstNull(string.Empty));
            Assert.True(ex.Message.EndsWith("str"));
        }

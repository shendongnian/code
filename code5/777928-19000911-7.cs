        public static void AssertNothingWasCalled<T>(this T mock)
        {
            var methodsToVerify = typeof (T)
                .GetMethods()
                .Where(m => !m.IsSpecialName);
            foreach (var method in methodsToVerify)
            {
                var arguments = BuildArguments(method);
                var action = new Action<T>(x => method.Invoke(x, arguments));
                mock.AssertWasNotCalled(action, y => y.IgnoreArguments());
            }
        }
        private static object[] BuildArguments(MethodInfo methodInfo)
        {
            return methodInfo
                .GetParameters()
                .Select(p => Arg<object>.Is.Anything)
                .ToArray();
        }

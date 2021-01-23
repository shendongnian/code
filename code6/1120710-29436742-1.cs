        private static void Main(string[] args)
        {
            string methodName = "AMethod";
            object[] parameters = new object [] {"Hello", "foo"};
            MethodInfo method = typeof(Program).GetMethod(methodName, BindingFlags.Static);
            string returnValue = (string)method.Invoke(null, parameters);
        }
        public static string AMethod(string parameter1, string parameter2)
        {
            return "xyz" + parameter1 + "abc" + parameter2;
        }

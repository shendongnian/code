    namespace Extensions
    {
        public static class MyConcreteClassExtensions
        {
            public static string MethodTwo(this MyConcreteClass concreteClass)
            {
                   // add new implementation here
                   return concreteClass.PropertyOne + " using extensions";
            }
        }
    }

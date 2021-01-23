    internal static class MyClassesExtensions
    {
        public static void InitTheStuff(this IDoThis obj)
        {
            // Do something here, for example:
            if (String.IsNullOrEmpty(obj.DoThisA))
                obj.DoThisA = "foo";
            else
                obj.DoThisB = obj.DoThisC;
        }
    }

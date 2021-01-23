    internal class Program {
        private static void Main( ) {
            System.Type.GetType("System.Console")
                .GetMethod("WriteLine",new[] {System.Type.GetType("System.String")})
                .Invoke(null,new object[]{"Hello World"});
        }
    }

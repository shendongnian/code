    public class MainClass
    {
        private static class Class1
        {
             // note the modifier change for Class2
             public static class Class2
             {
                 public const int Id = 2;
             }
        }
    
        public void getId()
        {
            var id = Class1.Class2.Id;
        }
    }

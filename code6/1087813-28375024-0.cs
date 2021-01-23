    class Program
    {
        static void Main(string[] args)
        {
            var listOfModel2 = new Model1();
            //You can call it from "object"
            listOfModel2.MyExtensionMethod();
            //Or directly as it is declared
            ObjectExtensions.MyExtensionMethod(listOfModel2);
        }
    }
    public static class ObjectExtensions
    {
        public static void MyExtensionMethod<T>(this T t)
        {
            //Do somthing
        }
    }

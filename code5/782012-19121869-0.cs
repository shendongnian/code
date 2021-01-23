    public class MyStaticClass
    {
        static int j; //static member
        int i;//instance member
        static void MyStaticMethod()
        {
            i = 0; // you can't access that
            j = 0; // you can access 
        }
    }

    public class BaseHome
    {
        static BaseHome Console = new BaseHome();
 
        public static void Main()
        {
           Console.WriteLine("A");
        }
 
        public void WriteLine(string s) {
            System.Console.WriteLine("BCA"); //Or multiple lines if you like
        }
 
    }

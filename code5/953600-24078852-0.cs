    public class BaseHome
    {
        public static void Main()
        {
           Console.WriteLine("A");
        }
        public static BaseHome Console
        {
            get{ return new BaseHome(); }
        }
        public void WriteLine(string s) {
            System.Console.WriteLine("BCA"); //Or multiple lines if you like
        }
    }

    public class GenerateRandomNum
    {
        private static string id = "";
       
        public static string RandomNum()
        { 
        
       Random rnd = new Random();
       for(int a = 0; a <8; a++)
          {
          id +=(string)rnd.Next(0,9); 
          }
       }
    }
   
    class TestRandom
    {
       public static void Main()
       {
           string Body = "Your New Value is " + GenerateRandomNum.RandomNum();
           mail.Body = Body;
       }
    }

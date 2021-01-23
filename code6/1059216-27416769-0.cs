    try{
        Directory.Create(...);
    }catch (IOException ex){
        try new Exception("Your disk protected");
    }
    public class MyException: Exception
    {
        public MyException()
        {
        }
    
        public MyException(string message)
            : base(message)
        {
        }
    
        public MyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

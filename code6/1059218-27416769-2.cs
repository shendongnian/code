    try{
        Directory.Create(...);
    }catch (IOException ex){
        throw new Exception("Directory cannot be created on your flash disk, because your disk protected");
    }
    catch(Exception ex){
        throw new Exception(ex.Message)
    }
    [Serializable]
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

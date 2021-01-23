    class YourLibrary
    {
        static void Main()
        {
            int [] v = null;
            try
            {
                v[1] = 10;
            }
            catch(Exception e)
            {
                throw new MyException(e);
            }
        }
    }
    public class MyException : Exception
    {        
        public MyException(Exception e):base(e.GetType().ToString() + e.Message)
        {            
        }
    }

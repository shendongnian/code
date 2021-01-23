    public void MyStartMethod
    {
        try
        {
            //do something
            MyBadMethod();
        }
        catch(MySpecialException mse)
        {
            //this is the higher level catch block, specifically catching MySpecialException 
        }
    }
    
    public void MyBadMethod()
    {
        try
        {
            //do something silly that causes an exception
        }
        catch (Exception e)
        {
            //do some logging
    
            throw new MySpecialException(e);
        }
    }
    
    public class MySpecialException : Exception 
    {   
        public MySpecialException(Exception e) { ...etc... }
    }

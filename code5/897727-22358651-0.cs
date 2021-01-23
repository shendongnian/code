    public class Helper
    {
        public void SomeMethod()
        {
            throw new InvalidCastException("I don't like this cast.");
        }
        public void SomeOtherMethod()
        {
            throw new ArgumentException("Your argument is invalid.");
        }
    }
    public class Caller
    {
        public void CallHelper()
        {
            try
            {
                new Helper().SomeMethod();
              
            }
            catch (ArgumentException exception)
            {
                // Do something there
            }
            catch (Exception exception)
            {
                // Do something here
            }
            try
            {
                new Helper().SomeOtherMethod();
            }
            catch (ArgumentException exception)
            {
                // Do something there
            }
            catch (Exception exception)
            {
                // Do something here
            }
        }
    }

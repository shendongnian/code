    public class MyClass
    {
        try
        {
            // do something
        } 
        catch(Exception ex)
        {
            LoggerHelper.WriteError("Problem doing something", ex, this.GetType());
        }
     }

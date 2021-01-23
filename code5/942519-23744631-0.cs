    public class Service
    {
      public bool DoWork()
      {
        bool success = false;
        try
        {
          //code to do work
          success = true;
        }
        catch(Exception ex)
        {
          //do something with the ex
          success = false;
        }
    
        return success;
        }
    }

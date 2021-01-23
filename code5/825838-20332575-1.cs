    public class HandlerServiceLocator
    {
   
      public static ResultHandler GetHandler(byte value)
      {
            switch(value)
            {
                case 0:
                    return null;
                case 1:
                    return  new ResultPrint();
                ...
            }
            return null;
      }
    }

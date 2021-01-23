    //Wrapper class
    public class MyWrapperClass
    {
         public YourReturnType MyFunction()
         {
             OriginalClass obj = new OriginalClass();
    
             //And inside this function call your original function
             return obj.OriginalFunction();
         }
    
    }

     static void Main(string[] args)
     {
       try
       {
           try   
           {
              Console.WriteLine("foo");
              throw new Exception("exception");   //error occurs here
           }   
           finally   //will execute this as it is the first exception statement
           {
               Console.WriteLine("foo's finally called");   
           }   
        }
        catch (Exception e)  // then this
        {
           Console.WriteLine("Exception caught");
        }
     }

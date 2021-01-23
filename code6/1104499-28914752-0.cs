    class myClass
    { 
         public List<delegate> eventHandlers = new  List<delegate>();
         public void someMethod()
         {
              //... do some work
              //... then call the events
              foreach(delegate d in eventHandlers)
              {
                   // we have no idea what the method name is that the delegate
                   // points to, but we dont need to know - the pointer to the 
                   // function is stored as a delegate, so we just execute the 
                   // delegate, which is a synonym for the function.
                   d();
              }
          }
     }
     
     public class Program()
     {
          public static void Main()
          {
              myClass class1 = new myClass();
              // 'longhand' version of setting up a delegate callback
              class1.eventHandlers.Add(new delegate(eventHandlerFunction));
              // This call will cause the eventHandlerFunction below to be 
              //
              class1.someMethod();
              // 'shorthand'
              class1.eventHandlers.Add(() => eventHandlerFunction());
          }
          public static eventHandlerFunction()
          {
               Console.WriteLine("I have been called");
          }

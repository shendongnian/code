    public class MyCustomEventArgs : EventArgs
    {
         // some implementation
         public MyCustomEventArgs() 
         {
         }
         public MyCustomEventArgs(object argument)
             : this()
         {
             ....
         }
    }

    public class Lua : SafeHandleZeroOrMinusOneIsInvalid 
    {
         private Lua() : base (true)
         {
         }
         override protected bool ReleaseHandle()
         {
             return NativeMethods.CloseHandle(this.handle); //Or how ever you would normally release the pointer when done
         }
         //Other methods that work on the pointer, it is accessed via "this.handle"
    }

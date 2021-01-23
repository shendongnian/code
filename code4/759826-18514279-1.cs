    // NOT VALID CODE
    public class Manager: IDisposable
    {
         // Tell the runtime to call resource.Dispose when disposing Manager
         using private UnmanagedResource resource;
    }

    use xaml code above
    in codebehind
    using System.ComponentModel;
    define class myclass :Idisposable
    {
    private System.ComponentModel.Container components = null;
    bool disposed;
    method1
    {
         code
    }
    method
    {
         code
    }
    myclass newobj = new myclass();
    newobj.Dispose();
    public void Dispose()
    {
       this.Dispose(true);
       GC.SuppressFinalize(this);
    }
    public virtual void Dispose(bool disposing)
    {
       if (!disposed)
       {
           if (disposing)
           {
               if (components != null)
               {
                  components.Dispose();
               }
           }
                disposed = true;
           }
      }
      public interface IDisposable
      {
          void Dispose();
      }
      protected bool IsDisposed
      {
          get;
          private set;
      }

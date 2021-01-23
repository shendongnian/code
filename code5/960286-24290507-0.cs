    public class MyThingWithResources : IDisposable
    {
        ~MyTHingWithResources()
        {
            // This is a finalizer and is an optional part.
            // Finalizers are not generally required, and are 
            // intended for clearing up unmanaged resources
            // that your class might hold
            // Finalizers are called by the garbage collector
            // So you can never be sure when they are going to
            // be called.
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // if disposing is true, then the method 
                // is being called as part of a managed disposal
                // this means it should be safe to dispose of managed 
                // resources (.Net classes such as System.IO.Stream )
            }
            
            // If disposing is false, the Dispose method was called 
            // from the finaliser, so you're in the last chance saloon 
            // as far as tidying stuff up is concerned.
            // Only unmanaged resources (and the objects that wrap them)
            // should be tidied up in this scenario
        }
    }

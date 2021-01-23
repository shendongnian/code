    class A : IDisposable
    {
        public void Dispose() {
          Dispose(true);
          GC.SuppressFinalize(this); // <- May be excluded
        }
   
        protected virtual void Dispose(Boolean disposing)... // <- "disposing" recommended by Microsoft
    }
    
    class B : A
    {
        protected override void Dispose(Boolean disposing) {
          // Dispose here all private resources of B
          ...
          base.Dispose(disposing);
        }
    }
    
    class C : B
    {
        protected override void Dispose(Boolean disposing) {
          // Dispose here all private resources of C
          ...
          base.Dispose(disposing);
        }
    }

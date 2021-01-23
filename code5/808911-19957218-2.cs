    public class ClassThatNeedsStaticFinalizer {
        // ... other class properties, methods, etc ...		
        #region Static Finalizer Emulation
        static readonly Finalizer finalizer = new Finalizer();
        private sealed class Finalizer
        {
            ~Finalizer()
            {
                 //  ... Do final stuff here ...
            }
        }
        #endregion
    }

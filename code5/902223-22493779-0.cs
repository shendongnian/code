    public class DFKCamera : IDFKStreamable
    {
        // IStreamable methods
        public void NewMethod() {}
    }
    // elsewhere...
    IDFKStreamable DLLObject = new DFKCamera();
    DLLObject.NewMethod();

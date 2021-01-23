    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    public class ServiceControlHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // Create a SafeHandle, informing the base class 
        // that this SafeHandle instance "owns" the handle,
        // and therefore SafeHandle should call 
        // our ReleaseHandle method when the SafeHandle 
        // is no longer in use. 
        private ServiceControlHandle()
            : base(true)
        {
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        override protected bool ReleaseHandle()
        {
            // Here, we must obey all rules for constrained execution regions. 
            return NativeMethods.CloseServiceHandle(this.handle);
            // If ReleaseHandle failed, it can be reported via the 
            // "releaseHandleFailed" managed debugging assistant (MDA).  This
            // MDA is disabled by default, but can be enabled in a debugger 
            // or during testing to diagnose handle corruption problems. 
            // We do not throw an exception because most code could not recover 
            // from the problem.
        }
    }

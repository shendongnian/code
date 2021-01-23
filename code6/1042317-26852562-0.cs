    public class ProcessWaitHandle : WaitHandle
    {
        private readonly Process process;
        public ProcessWaitHandle(Process process)
        {
            this.process = process;
            this.SafeWaitHandle = new SafeWaitHandle(process.Handle, false);
        }
    }
    var waitHandles = new WaitHandle[2]
    {
        waitHandleExit,
        new ProcessWaitHandle(process)
    };
    int waitResult = WaitHandle.WaitAny(waitHandles, timeOut);

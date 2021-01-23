        public class ProcessWindowWrapper : IDisposable
        {
            Process process;
            public ProcessWindowWrapper(Process process)
            {
                this.process = process;
            }
            public Process Process { get { return process; } }
            public IntPtr MainWindowHandle
            {
                get
                {
                    try
                    {
                        return (process == null ? IntPtr.Zero : process.MainWindowHandle);
                    }
                    catch (InvalidOperationException)
                    {
                        // Process exited
                        return IntPtr.Zero;
                    }
                }
            }
            public override string ToString()
            {
                return (process == null ? string.Empty : process.MainWindowTitle);
            }
            #region IDisposable Members
            public void Dispose()
            {
                // Dispose of unmanaged resources.
                Dispose(true);
                // Suppress finalization.  Since this class actually has no finalizer, this does nothing.
                GC.SuppressFinalize(this);
            }
            void Dispose(bool disposing)
            {
                if (disposing)
                {
                    var process = Interlocked.Exchange(ref this.process, null);
                    if (process != null)
                        process.Dispose();
                }
            }
            #endregion
        }

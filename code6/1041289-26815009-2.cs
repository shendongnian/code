        public class ProcessWindowWrapper
        {
            readonly Process process;
            public ProcessWindowWrapper(Process process)
            {
                this.process = process;
            }
            public IntPtr MainWindowHandle
            {
                get
                {
                    return (process == null || process.HasExited ? IntPtr.Zero : process.MainWindowHandle);
                }
            }
            public override string ToString()
            {
                return (process == null ? string.Empty : process.MainWindowTitle);
            }
        }

        public IntPtr Handle
        {
            get
            {
                this.EnsureState(Process.State.Associated);
                return this.OpenProcessHandle().DangerousGetHandle();
            }
        }

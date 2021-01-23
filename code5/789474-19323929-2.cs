     public static class ConsoleOutRedirector
        {
        #region Constants
    
        private const Int32 STD_OUTPUT_HANDLE = -11;
    
        #endregion
    
        #region Externals
    
        [DllImport("Kernel32.dll")]
        extern static Boolean SetStdHandle(Int32 nStdHandle, SafeHandleZeroOrMinusOneIsInvalid handle);
        [DllImport("Kernel32.dll")]
        extern static SafeFileHandle GetStdHandle(Int32 nStdHandle);
    
        #endregion
    
        #region Methods
    
        public static void GetOutput(Action action)
        {
          Debug.Assert(action != null);
    
          using (var server = new AnonymousPipeServerStream(PipeDirection.Out))
          {
            var defaultHandle = GetStdHandle(STD_OUTPUT_HANDLE);
    
            Debug.Assert(!defaultHandle.IsInvalid);
            Debug.Assert(SetStdHandle(STD_OUTPUT_HANDLE, server.SafePipeHandle));
            try
            {
              action();
            }
            finally
            {
              Debug.Assert(SetStdHandle(STD_OUTPUT_HANDLE, defaultHandle));
            }
          }
        }
    
        #endregion
      }

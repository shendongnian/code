      /// <summary>
      /// A set of common, useful HRESULTS, and related functionality
      /// </summary>
      public enum HResult
      {
        /// <summary>
        /// OK/true/Success
        /// </summary>
        S_OK = 0,
        /// <summary>
        /// False
        /// </summary>
        S_FALSE = 1,
        /// <summary>
        /// The method is not implemented
        /// </summary>
        E_NOTIMPL = unchecked((int)0x80004001),
        /// <summary>
        /// The interface is not supported
        /// </summary>
        E_NOINTERFACE = unchecked((int)0x80004002),
        /// <summary>
        /// Bad Pointer
        /// </summary>
        E_POINTER = unchecked((int)0x8004003),
        /// <summary>
        /// General failure HRESULT
        /// </summary>
        E_FAIL = unchecked((int)0x8004005),
        /// <summary>
        /// Invalid Argument
        /// </summary>
        E_INVALIDARG = unchecked((int)0x80070057),
        /// <summary>
        /// Insufficient buffer
        /// </summary>
        ERROR_INSUFFICIENT_BUFFER = unchecked((int)0x8007007A),
        /// <summary>
        /// HRESULT for failure to find or load an appropriate runtime
        /// </summary>
        CLR_E_SHIM_RUNTIMELOAD = unchecked((int)0x80131700),
    
        SEVERITY = unchecked((int)0x80000000)
      }

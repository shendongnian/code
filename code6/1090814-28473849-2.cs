    /// <summary>
                ///     Fill a buffer with cryptographically random bytes
                /// </summary>
                [DllImport("advapi32", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool CryptGenRandom(SafeCspHandle hProv,
                                                         int dwLen,
                                                         [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pbBuffer);
 
 

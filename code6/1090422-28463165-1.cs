    //-----------------------------------------------------------------------
    // <copyright file="ProcessExtensions.cs" company="DockOfTheBay">
    //     http://www.dotbay.be
    // </copyright>
    // <summary>Defines the ProcessExtensions class.</summary>
    //-----------------------------------------------------------------------
     
    namespace DockOfTheBay
    {
        using System;
        using System.Diagnostics;
        using System.Runtime.InteropServices;
        using System.Security.Principal;
     
        /// <summary>
        /// Extension Methods for the System.Diagnostics.Process Class.
        /// </summary>
        public static class ProcessExtensions
        {
            /// <summary>
            /// Required to query an access token.
            /// </summary>
            private static uint TOKEN_QUERY = 0x0008;
     
            /// <summary>
            /// Returns the WindowsIdentity associated to a Process
            /// </summary>
            /// <param name="process">The Windows Process.</param>
            /// <returns>The WindowsIdentity of the Process.</returns>
            /// <remarks>Be prepared for 'Access Denied' Exceptions</remarks>
            public static WindowsIdentity WindowsIdentity(this Process process)
            {
                IntPtr ph = IntPtr.Zero;
                WindowsIdentity wi = null;
                try
                {
                    OpenProcessToken(process.Handle, TOKEN_QUERY, out ph);
                    wi = new WindowsIdentity(ph);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (ph != IntPtr.Zero)
                    {
                        CloseHandle(ph);
                    }
                }
     
                return wi;
            }
     
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);
     
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr hObject);
        }
    }

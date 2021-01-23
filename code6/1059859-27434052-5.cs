            IntPtr pDuplicateTokenHandle = IntPtr.Zero;
            try
            {
                pDuplicateTokenHandle = ImpersonateUserClass.ImpersonateUser(user.UserName, user.Domain, user.Password);
                string @path = Path.GetDirectoryName(strProcessFilename);
                var sec = new NativMethodes.SECURITY_ATTRIBUTES();
                var si = new NativMethodes.STARTUPINFO();
                var pi = new NativMethodes.PROCESS_INFORMATION();
                /*
                    Click Start, Run. 
                    Type gpedit.msc and click ok. 
                    In the group policy editor: 
                    Expand Windows Settings 
                    Expand Security Settings 
                    Expand Local Policies 
                    Click on User Rights Assignment                  
                 */
                if (NativMethodes.CreateProcessAsUser(pDuplicateTokenHandle, strProcessFilename,
                    string.Format("{0} {1}", 0, strCommand), ref sec, ref sec, false,
                    (uint)NativMethodes.CreateProcessFlags.CREATE_UNICODE_ENVIRONMENT, IntPtr.Zero,
                    @path, ref si, out pi))
                {
                    int err = Marshal.GetLastWin32Error();
                    if (err != 0)
                        throw new Exception("Failed CreateProcessAsUser error: " + new Win32Exception());
                    try
                    {
                        _process = Process.GetProcessById(pi.dwProcessId);
                        if (_process != null)
                        {
                            _process.WaitForExit();
                        }
                        else
                        {
                            NativMethodes.WaitForSingleObject(pDuplicateTokenHandle, NativMethodes.INFINITE);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Not able to wait for the program", ex);
                    }
                }
                else
                    throw new Exception("Failed CreateProcessAsUser error: " + new Win32Exception());
            }
            finally
            {
                if (pDuplicateTokenHandle != IntPtr.Zero)
                    NativMethodes.CloseHandle(pDuplicateTokenHandle);
            }
            return "";
